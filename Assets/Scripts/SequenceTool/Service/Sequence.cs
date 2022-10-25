using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Sequence
{

    List<Action> actionList;
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

                        break;
                    }
                case ActionType.ShowDialogue:
                    {

                        break;
                    }
                case ActionType.EndSequence:
                    {

                        break;
                    }
                case ActionType.LoadSequence:
                    {

                        break;
                    }
            }
        }
    }

    public IEnumerator Execute()
    {
        List<Task> tasks = new List<Task>();
        foreach(var action in actionList)
        {
            tasks.Add(action.Execute());
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
}
