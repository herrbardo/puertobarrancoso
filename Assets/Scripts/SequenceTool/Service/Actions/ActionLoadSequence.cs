using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ActionLoadSequence : Action
{
    ActionLoadSequenceData data;
    public ActionLoadSequence(ActionLoadSequenceData data) : base(data)
    {
        this.data = data;
    }

    public override async Task Execute(Sequence seq)
    {
        IsDone = Completed = false;
        var sequence = await GameObjectFactory.LoadSequence(data.nextSequence);
        SequenceManager.Instance.AddSequence(sequence);
        IsDone = Completed = true;
    }
}
