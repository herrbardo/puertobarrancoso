using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ActionPause : Action
{
    public ActionPause(ActionPauseData data) : base(data)
    {
    }

    bool pause = true;

    public override async Task Execute(Sequence seq)
    {
        IsDone = Completed = false;

        while (pause)
            await Task.Delay(10);
        IsDone = Completed = true;

    }

    public override bool Continue()
    {
        pause = false;
        return true;
    }
}
