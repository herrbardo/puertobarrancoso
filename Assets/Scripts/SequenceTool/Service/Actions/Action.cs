using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Action
{
    protected ActionData _data;
    protected Action(ActionData data)
    {
        _data = data;
    }
    public bool IsDone { get; set; }
    public bool Completed { get; set; }
    public abstract Task Execute();

    


}
