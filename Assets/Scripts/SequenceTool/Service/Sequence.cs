using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Sequence
{
    public bool Finished { get; private set; } = false;
    public IEnumerator Task { get; private set; }
    List<Action> actionList;
    Dictionary<string, GameObject> InstantiatedGO = new();
    public Sequence(SequenceData sequence) 
    {
        actionList = new List<Action>();
        foreach (var actionData in sequence.actions)
        {
            switch (actionData.action.type)
            {
                case ActionType.Wait:
                    {
                        var action = new ActionWait(actionData.action.GetAction<ActionWaitData>());
                        actionList.Add(action);
                        break;
                    }
                case ActionType.Show:
                    {
                        var action = new ActionShow(actionData.action.GetAction<ActionShowData>());
                        actionList.Add(action);
                        break;
                    }
                case ActionType.Hide:
                    {
                        var action = new ActionHide(actionData.action.GetAction<ActionHideData>());
                        actionList.Add(action);
                        break;
                    }
                case ActionType.ShowDialogue:
                    {

                        break;
                    }
                case ActionType.EndSequence:
                    {
                        var action = new ActionEndSequence(actionData.action.GetAction<ActionEndSequenceData>());
                        actionList.Add(action);
                        break;
                    }
                case ActionType.LoadSequence:
                    {
                        var action = new ActionLoadSequence(actionData.action.GetAction<ActionLoadSequenceData>());
                        actionList.Add(action);
                        break;
                    }
            }
        }
        Task = Execute();
    }

    public IEnumerator Execute()
    {
        List<Task> tasks = new List<Task>();
        foreach(var action in actionList)
        {
            tasks.Add(action.Execute(this));
            while (!action.IsDone)
                yield return null;
        }

        //wait for all actions completition
        foreach (var action in actionList)
        {
            while (!action.Completed)
                yield return null;
        }
        tasks.Clear();
    }

    public void AddGameObject(string address, GameObject obj)
    {
        InstantiatedGO.Add(address, obj);
    }

    public void RemoveGameObject(string address)
    {
        if(InstantiatedGO.ContainsKey(address))
        {
            GameObject.Destroy(InstantiatedGO[address]);
            InstantiatedGO.Remove(address);
        }
    }

    public GameObject GetGameObject(string address)
    {
        if (InstantiatedGO.ContainsKey(address))
            return InstantiatedGO[address];
        else return null;
    }

    public void EndSequence()
    {
        foreach(var go in InstantiatedGO.Values)
        {
            GameObject.Destroy(go);
        }
        InstantiatedGO.Clear();
        Finished = true;
    }
}
