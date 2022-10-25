using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ActionContainer
{
    [HideInInspector]
    public string Type;
    [SerializeReference]
    [HideInInspector]
    public Action action;
}

[CreateAssetMenu(fileName = "newSequence", menuName = "SequenceTool/Sequence", order = 51)]
public class Sequence : ScriptableObject
{
    [SerializeField]
    [SerializeReference]
    public ActionContainer[] actions;


}



