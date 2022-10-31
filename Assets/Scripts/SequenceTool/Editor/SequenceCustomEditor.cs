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
using System.Linq;
using static Codice.CM.Common.CmCallContext;
using PixelCrushers.DialogueSystem;

[CustomEditor(typeof(SequenceData))]
public class SequenceCustomEditor : Editor
{
    SerializedObject serialized;

    string[] assetsNames;
    string[] spriteNames;
    string[] prefabNames;

    string[] dialogueNames;
    string[] sequenceNames;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        var sequence = (SequenceData)target;

        //if(serialized == null)
        serialized = new SerializedObject(sequence);

        prefabNames = GetAddressableEntries("Prefabs");
        spriteNames = GetAddressableEntries("Sprites");

        List<string> assets = new List<string>();
        foreach (string asset in prefabNames)
        {
            assets.Add(asset);
        }

        foreach (string asset in spriteNames)
        {
            assets.Add(asset);
        }

        assetsNames = assets.ToArray();

        {
            var setting = AddressableAssetSettingsDefaultObject.Settings;
            var group = setting.FindGroup("Dialogues");
            var dialoguePathList = new List<string>();

            foreach (var entry in group.entries)
            {
                dialoguePathList.Add(entry.AssetPath);
            }
            List<string> dialogues = new List<string>();
            foreach(var dialoguePath in dialoguePathList)
            {
                var d = AssetDatabase.LoadAssetAtPath<DialogueDatabase>(dialoguePath);
                foreach (var conversation in d.conversations)
                {
                    dialogues.Add(conversation.Title);
                }

                
            }
            dialogueNames = dialogues.ToArray();
        }
        //var dialogues = GetAddressableEntries("Dialogues");
        
        sequenceNames = GetAddressableEntries("Sequences");

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
                action.action = ValidateType<ActionWaitData>(prop.FindPropertyRelative("action"));
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
            DrawAction(action, prop, sequence, i);
        }
        /**/
        serialized.ApplyModifiedProperties();

    }

    public string[] GetAddressableEntries(string key)
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
    private ActionData GetAction(ActionType type, SerializedProperty prop)
    {
        switch (type)
        {
            case ActionType.Wait:
                {
                    
                    return ValidateType<ActionWaitData>(prop);
                }
            case ActionType.Show:
                {
                    return ValidateType<ActionShowData>(prop);
                }
            case ActionType.Hide:
                {
                    return ValidateType<ActionHideData>(prop);
                }
            case ActionType.ShowDialogue:
                {
                    return ValidateType<ActionShowDialogueData>(prop);
                }
            case ActionType.EndSequence:
                {
                    return ValidateType<ActionEndSequenceData>(prop);
                }
            case ActionType.LoadSequence:
                {
                    return ValidateType<ActionLoadSequenceData>(prop);
                }
            case ActionType.Pause:
                {
                    return ValidateType<ActionPauseData>(prop);
                }
            default: return ValidateType<ActionWaitData>(prop);
        }
    }

    void DrawAction(ActionContainer actionContainer, SerializedProperty prop, SequenceData sequence, int index)
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
                    DrawActionWait((ActionWaitData)action, actionProp);
                    break;
                }
            case ActionType.Show:
                {
                    
                    DrawActionShow((ActionShowData)action, actionProp, sequence);
                    break;
                }
            case ActionType.Hide:
                {
                    DrawActionHide((ActionHideData)action, actionProp, sequence);
                    break;
                }
            case ActionType.ShowDialogue:
                {
                    DrawActionShowDialogue((ActionShowDialogueData)action, actionProp);
                    break;
                }
            case ActionType.EndSequence:
                {
                    DrawActionEndSequence((ActionEndSequenceData)action, actionProp);
                    break;
                }
            case ActionType.LoadSequence:
                {
                    DrawActionLoadSequence((ActionLoadSequenceData)action, actionProp);
                    break;
                }
            case ActionType.Pause:
                {
                    DrawPause(action, sequence);
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

    private void DrawPause(ActionData action, SequenceData sequence)
    {
        int i = 0;
        foreach(var a in sequence.actions)
        {
            if(a.action.type == ActionType.Pause)
            {
                i++;
            }
            if(a.action == action)
            {
                break;
            }
        }
        EditorGUILayout.LabelField("Number: " + i);

    }

    void DrawActionWait(ActionWaitData action, SerializedProperty prop)
    {

        var seconds = prop.FindPropertyRelative(nameof(action.time));
        if(seconds != null)
            seconds.floatValue = EditorGUILayout.FloatField("Seconds", seconds.floatValue);
        
    }

    void DrawActionShow(ActionShowData action, SerializedProperty prop, SequenceData sequence)
    {
        var address = prop.FindPropertyRelative(nameof(action.objectAddress));
        var objectCopyIndex = prop.FindPropertyRelative(nameof(action.objectCopyIndex));
        var prefabType = prop.FindPropertyRelative(nameof(action.PrefabType));
        var position = prop.FindPropertyRelative(nameof(action.position));
        var layerField = prop.FindPropertyRelative(nameof(action.layerField));
        var layer = prop.FindPropertyRelative(nameof(action.layer));
        var orderInLayer = prop.FindPropertyRelative(nameof(action.orderInLayer));
        var transition = prop.FindPropertyRelative(nameof(action.transition));

        if (prefabType != null)
            prefabType.intValue = (int)(PrefabType)EditorGUILayout.EnumPopup("PrefabType", (PrefabType)prefabType.intValue);

        string[] assets;
        if (prefabType.intValue == (int)PrefabType.Gameobject)
            assets = prefabNames;
        else
            assets = spriteNames;
        if (address != null)
        {
            int objindex = GetIndex<string>(address.stringValue, assets);
            objindex = EditorGUILayout.Popup("Object", objindex, assets);
            address.stringValue = assets[objindex];
        }
        if (objectCopyIndex != null)
        {
            objectCopyIndex.intValue = GetCopyIndex(action, sequence);
            EditorGUILayout.IntField("Copy index: ", objectCopyIndex.intValue);
        }
        if (position != null)
            position.vector2Value = EditorGUILayout.Vector2Field("Position", position.vector2Value);
        if(layerField != null)
            layerField.intValue = (int)(SortingLayerField) EditorGUILayout.EnumPopup("Layer", (SortingLayerField)layerField.intValue);
        if (layer != null)
        {
            SortingLayerField name = (SortingLayerField)layerField.intValue;
            layer.stringValue = "" + name;
        }
        if(orderInLayer != null)
            orderInLayer.intValue = EditorGUILayout.IntField("Order In Layer", orderInLayer.intValue);
        if (transition != null)
        {
            transition.intValue = (int)(TransitionIn)EditorGUILayout.EnumPopup("Transition", (TransitionIn)transition.intValue);
            if(transition.intValue != (int)TransitionIn.None)
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

    void DrawActionHide(ActionHideData action, SerializedProperty prop, SequenceData sequence)
    {
        var address = prop.FindPropertyRelative(nameof(action.objectAddress));
        var objectCopyIndex = prop.FindPropertyRelative(nameof(action.objectCopyIndex));
        var transition = prop.FindPropertyRelative(nameof(action.transition));

        if (address != null)
        {
            int index = GetIndex<string>(address.stringValue, assetsNames);
            index = EditorGUILayout.Popup("Object", index, assetsNames);
            address.stringValue = assetsNames[index];
        }
        if(objectCopyIndex != null)
        {
            var count = GetCopyCount(action, sequence);
            objectCopyIndex.intValue = EditorGUILayout.Popup("Copy index: ", Mathf.Min(objectCopyIndex.intValue, count-1), CopyCountArray(count));
        }
        if (transition != null)
        {
            transition.intValue = (int)(TransitionOut)EditorGUILayout.EnumPopup("Transition", (TransitionOut)transition.intValue);
            if (transition.intValue != (int)TransitionOut.None)
            {
                var time = prop.FindPropertyRelative(nameof(action.time));
                time.floatValue = EditorGUILayout.FloatField("Seconds", time.floatValue);
            }
        }

    }

    void DrawActionShowDialogue(ActionShowDialogueData action, SerializedProperty prop)
    {
        var address = prop.FindPropertyRelative(nameof(action.dialogue));
        if (address != null)
        {
            int index = GetIndex<string>(address.stringValue, dialogueNames);
            index = EditorGUILayout.Popup("Dialogue", index, dialogueNames);
            address.stringValue = dialogueNames[index];
        }
    }

    void DrawActionEndSequence(ActionEndSequenceData action, SerializedProperty prop)
    {

    }

    void DrawActionLoadSequence(ActionLoadSequenceData action, SerializedProperty prop)
    {
        var address = prop.FindPropertyRelative(nameof(action.nextSequence));
        if (address != null)
        {
            int index = GetIndex<string>(address.stringValue, sequenceNames);
            index = EditorGUILayout.Popup("Dialogue", index, sequenceNames);
            address.stringValue = sequenceNames[index];
        }
    }

    int GetCopyIndex(ActionShowData action, SequenceData sequence)
    {
        int idx = 0;

        for(int i=0; i< sequence.actions.Length; i++)
        {
            var actionContainer = sequence.actions[i];

            if(actionContainer.action.type == ActionType.Show)
            {
                ActionShowData current = (ActionShowData)actionContainer.action;
                if (current == action)
                    return idx;
                else if (current.objectAddress.Equals(action.objectAddress))
                    idx++;
            }

        }


        return idx;
    }

    int GetCopyCount(ActionHideData action, SequenceData sequence)
    {
        int idx = 0;
        for (int i = 0; i < sequence.actions.Length; i++)
        {
            var actionContainer = sequence.actions[i];

            if (actionContainer.action.type == ActionType.Show)
            {
                ActionShowData current = (ActionShowData)actionContainer.action;
               
                if (current.objectAddress.Equals(action.objectAddress))
                    idx++;
            }
            if (actionContainer.action.type == ActionType.Hide)
            {
                ActionHideData current = (ActionHideData)actionContainer.action;

                if (current == action)
                    return idx;
            }


        }

        return idx;
    }

    string[] CopyCountArray(int count)
    {
        string[] array = new string[count];
        for(int i=0; i<count; i++)
        {
            array[i] = "Copy (" + i + ")";
        }
        return array;
    }


    ActionType GetType(ActionData action)
    {
        if (action is ActionWaitData)
            return ActionType.Wait;
        if (action is ActionShowData)
            return ActionType.Show;
        if (action is ActionHideData)
            return ActionType.Hide;
        if (action is ActionShowDialogueData)
            return ActionType.ShowDialogue; 
        if (action is ActionEndSequenceData)
            return ActionType.EndSequence; 
        if (action is ActionLoadSequenceData)
            return ActionType.LoadSequence;
        if(action is ActionPauseData)
            return ActionType.Pause;
        return ActionType.None;

    }
}
