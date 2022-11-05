using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ActionShowDialogue : Action
{
    ActionShowDialogueData data;
    public ActionShowDialogue(ActionShowDialogueData data) : base(data)
    {
        this.data = data;
    }

    public override async Task Execute(Sequence seq)
    {
        Debug.Log("Action: Show DIALOGUE " + data.dialogue);

        IsDone = Completed = false;

        //LoadDialogue

        DialogueSystem.Instance.ShowDialogue(data.dialogue);

        IsDone = true;
        /*
        var obj = await GameObjectFactory.InstantiateGameObject("ConversationStart");

        var time = 0f;
        while (time < 1)
        {
            await Task.Delay(100);
            time += 0.1f;
        }
        GameObject.Destroy(obj);
        /**/
        Completed = true;

    }

}
