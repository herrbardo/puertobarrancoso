using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ActionPlayAnimation : Action
{
    public ActionPlayAnimation(ActionPlayAnimationData data) : base(data)
    {
    }

    public override Task Execute(Sequence seq)
    {
        throw new System.NotImplementedException();
    }
}
