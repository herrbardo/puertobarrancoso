using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using Unity.Burst.Intrinsics;
using static UnityEngine.GraphicsBuffer;
using UnityEditor.UIElements;
using UnityEngine.AddressableAssets;
using UnityEditor.AddressableAssets;

[CustomEditor(typeof(Sequence))]
public class SequenceCustomEditor : Editor
{
    SerializedObject serialized;

    string[] assetsNames;
    string[] dialogueNames;
    string[] sequenceNames;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        var sequence = (Sequence)target;

        //if(serialized == null)
        serialized = new SerializedObject(sequence);

        assetsNames = SetAddressableEntries("Prefabs");
        dialogueNames = SetAddressableEntries("Dialogues");
        sequenceNames = SetAddressableEntries("Sequences");

        var actionsProp = serialized.FindProperty("actions");

        for (int i=0; i< actionsProp.arraySize; i++)
        {
            var action = sequence.actions[i];
            var prop = actionsProp.GetArrayElementAtIndex(i);

            if (action == null)
            {
                action = ValidateType<ActionContainer>(prop);
            }
            if (action.action == null)
            {
                action.action = ValidateType<ActionWait>(prop.FindPropertyRelative("action"));
                prop.serializedObject.ApplyModifiedProperties();
            }
            prop.FindPropertyRelative("Type").stringValue = "" + i + ": " + GetType(action.action);

            action.Type = ""+ i + ": " + GetType(action.action);

        }
        /**/
        for (int i = 0; i < sequence.actions.Length; i++)
        {
            var action = sequence.actions[i];

            var prop = serialized.FindProperty("actions").GetArrayElementAtIndex(i);
            DrawAction(action, prop, i);
        }
        /**/
        serialized.ApplyModifiedProperties();

    }

    public string[] SetAddressableEntries(string key)
    {
        var setting = AddressableAssetSettingsDefaultObject.Settings;
        var group = setting.FindGroup(key);
        var assetsNamesList = new List<string>();

        foreach (var entry in group.entries)
        {
            assetsNamesList.Add(entry.address);
        }
        return assetsNamesList.ToArray();
    }

    public T ValidateType<T>(SerializedProperty action) where T : new()
    {
        
        var newAction = Activator.CreateInstance<T>();

        //newAction.type = baseAction.type;
        action.managedReferenceValue = newAction;

        action.serializedObject.ApplyModifiedProperties();
        return newAction;
        
    }
    private Action GetAction(ActionType type, SerializedProperty prop)
    {
        switch (type)
        {
            case ActionType.Wait:
                {
                    
                    return ValidateType<ActionWait>(prop);
                }
            case ActionType.Show:
                {
                    return ValidateType<ActionShow>(prop);
                }
            case ActionType.Hide:
                {
                    return ValidateType<ActionHide>(prop);
                }
            case ActionType.ShowDialogue:
                {
                    return ValidateType<ActionShowDialogue>(prop);
                }
            case ActionType.EndSequence:
                {
                    return ValidateType<ActionEndSequence>(prop);
                }
            case ActionType.LoadSequence:
                {
                    return ValidateType<ActionLoadSequence>(prop);
                }
            default: return ValidateType<ActionWait>(prop);
        }
    }

    void DrawAction(ActionContainer actionContainer, SerializedProperty prop, int index)
    {
        EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginVertical("Box");
        EditorGUILayout.LabelField(""+index);
        var prevType = GetType(actionContainer.action);
        actionContainer.action.type = (ActionType)EditorGUILayout.EnumPopup("Action", prevType);
        var actionProp = prop.FindPropertyRelative("action");
        if (actionContainer.action.type != prevType)
        {
            actionContainer.action = GetAction(actionContainer.action.type, actionProp);
        }
        var action = actionContainer.action;
        actionProp = prop.FindPropertyRelative("action");
        switch (action.type)
        {
            case ActionType.Wait:
                {
                    DrawActionWait((ActionWait)action, actionProp);
                    break;
                }
            case ActionType.Show:
                {
                    DrawActionShow((ActionShow)action, actionProp);
                    break;
                }
            case ActionType.Hide:
                {
                    DrawActionHide((ActionHide)action, actionProp);
                    break;
                }
            case ActionType.ShowDialogue:
                {
                    DrawActionShowDialogue((ActionShowDialogue)action, actionProp);
                    break;
                }
            case ActionType.EndSequence:
                {
                    DrawActionEndSequence((ActionEndSequence)action, actionProp);
                    break;
                }
            case ActionType.LoadSequence:
                {
                    DrawActionLoadSequence((ActionLoadSequence)action, actionProp);
                    break;
                }
        }
        //var wait = actionProp.FindPropertyRelative(nameof(action.WaitForNext));
        //if(wait != null)
        //{
        //    wait.boolValue = EditorGUILayout.Toggle("Wait For Next", wait.boolValue);
        //}
        EditorGUILayout.EndVertical();

        EditorGUILayout.LabelField("------------------------------------");
        EditorGUILayout.EndVertical();

    }

    void DrawActionWait(ActionWait action, SerializedProperty prop)
    {

        var seconds = prop.FindPropertyRelative(nameof(action.time));
        if(seconds != null)
            seconds.floatValue = EditorGUILayout.FloatField("Seconds", seconds.floatValue);
        
    }

    void DrawActionShow(ActionShow action, SerializedProperty prop)
    {
        var address = prop.FindPropertyRelative(nameof(action.objectAddress));
        var position = prop.FindPropertyRelative(nameof(action.position));
        var layerField = prop.FindPropertyRelative(nameof(action.layerField));
        var layer = prop.FindPropertyRelative(nameof(action.layer));
        var orderInLayer = prop.FindPropertyRelative(nameof(action.orderInLayer));
        var transition = prop.FindPropertyRelative(nameof(action.transition));

        if (address != null)
        {
            int index = GetIndex<string>(address.stringValue, assetsNames);
            index = EditorGUILayout.Popup("Object", index, assetsNames);
            address.stringValue = assetsNames[index];
        }
        if(position != null)
            position.vector2Value = EditorGUILayout.Vector2Field("Position", position.vector2Value);
        if(layerField != null)
            layerField.intValue = (int)(SortingLayerField) EditorGUILayout.EnumPopup("Layer", (SortingLayerField)layerField.intValue);
        if(layer != null)
            layer.stringValue = "" + layer.stringValue;
        if(orderInLayer != null)
            orderInLayer.intValue = EditorGUILayout.IntField("Order In Layer", orderInLayer.intValue);
        if (transition != null)
        {
            transition.intValue = (int)(Transition)EditorGUILayout.EnumPopup("Transition", (Transition)transition.intValue);
            if(transition.intValue != (int)Transition.None)
            {
                var time = prop.FindPropertyRelative(nameof(action.time));
                time.floatValue = EditorGUILayout.FloatField("Seconds", time.floatValue);
            }
        }

    }

    int GetIndex<T>(T asset, T[] array)
    {
        for(int i=0; i<array.Length; i++)
        {
            if (array[i].Equals(asset))
                return i;
        }
        return 0;
    }

    void DrawActionHide(ActionHide action, SerializedProperty prop)
    {
        var address = prop.FindPropertyRelative(nameof(action.objectAddress));
        var transition = prop.FindPropertyRelative(nameof(action.transition));

        if (address != null)
        {
            int index = GetIndex<string>(address.stringValue, assetsNames);
            index = EditorGUILayout.Popup("Object", index, assetsNames);
            address.stringValue = assetsNames[index];
        }
        if (transition != null)
        {
            transition.intValue = (int)(Transition)EditorGUILayout.EnumPopup("Transition", (Transition)transition.intValue);
            if (transition.intValue != (int)Transition.None)
            {
                var time = prop.FindPropertyRelative(nameof(action.time));
                time.floatValue = EditorGUILayout.FloatField("Seconds", time.floatValue);
            }
        }

    }

    void DrawActionShowDialogue(ActionShowDialogue action, SerializedProperty prop)
    {
        var address = prop.FindPropertyRelative(nameof(action.dialogue));
        if (address != null)
        {
            int index = GetIndex<string>(address.stringValue, dialogueNames);
            index = EditorGUILayout.Popup("Dialogue", index, dialogueNames);
            address.stringValue = dialogueNames[index];
        }
    }

    void DrawActionEndSequence(ActionEndSequence action, SerializedProperty prop)
    {

    }

    void DrawActionLoadSequence(ActionLoadSequence action, SerializedProperty prop)
    {
        var address = prop.FindPropertyRelative(nameof(action.nextSequence));
        if (address != null)
        {
            int index = GetIndex<string>(address.stringValue, sequenceNames);
            index = EditorGUILayout.Popup("Dialogue", index, sequenceNames);
            address.stringValue = sequenceNames[index];
        }
    }

    ActionType GetType(Action action)
    {
        if (action is ActionWait)
            return ActionType.Wait;
        if (action is ActionShow)
            return ActionType.Show;
        if (action is ActionHide)
            return ActionType.Hide;
        if (action is ActionShowDialogue)
            return ActionType.ShowDialogue; 
        if (action is ActionEndSequence)
            return ActionType.EndSequence; 
        if (action is ActionLoadSequence)
            return ActionType.LoadSequence;
        return ActionType.None;

    }
}
