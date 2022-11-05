using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ActionWait : Action
{
    ActionWaitData data;
    public ActionWait(ActionWaitData data) : base(data)
    {
        this.data = data;
        IsDone = false;
    }

    public override async Task Execute(Sequence seq)
    {
        Debug.Log("Action: Wait for " + data.time);
        IsDone = Completed = false;
        await Task.Delay((int)(1000 * data.time));
        IsDone = Completed = true;
    }
}
