using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ActionPlaySoundEffect : Action
{
    public ActionPlaySoundEffect(ActionPlaySoundEffectData data) : base(data)
    {
    }

    public override Task Execute(Sequence seq)
    {
        throw new System.NotImplementedException();
    }
}
