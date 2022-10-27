using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ActionEndSequence : Action
{
    ActionEndSequenceData data;
    public ActionEndSequence(ActionEndSequenceData data) : base(data)
    {
        this.data = data;
    }

    public override Task Execute(Sequence seq)
    {
        seq.EndSequence();
        return Task.CompletedTask;
    }
}
