using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ActionContainer
{
    //[HideInInspector]
    public string Type;
    [SerializeReference]
    [HideInInspector]
    public ActionData action;
}

[CreateAssetMenu(fileName = "new Sequence", menuName = "SequenceTool/Sequence", order = 51)]
public class SequenceData : ScriptableObject
{
    [SerializeField]
    [SerializeReference]
    public ActionContainer[] actions;


}



