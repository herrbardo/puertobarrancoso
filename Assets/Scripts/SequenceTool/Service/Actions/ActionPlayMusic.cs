using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ActionPlayMusic : Action
{
    public ActionPlayMusic(ActionPlayMusicData data) : base(data)
    {
    }

    public override Task Execute(Sequence seq)
    {
        throw new System.NotImplementedException();
    }
}
