using UnityEngine;

public enum Transition
{
    None,
    FadeIn,
    FadeOut,
}
public enum ActionType
{
    None = 0,
    Wait = 1,
    Show = 2,
    Hide = 3,
    ShowDialogue = 4,
    EndSequence = 5,
    LoadSequence = 6,
}

public enum SortingLayerField
{
    Background,
    ObjectsBack,
    NPC,
    ObjectsFront,
    Dialogue,
    Foreground,

}

[System.Serializable]
public abstract class ActionData
{
    public ActionType type { get; set; }

    public T GetAction<T>() where T: ActionData
    {
        return (T)this;
    }
    //public bool WaitForNext;
}

[System.Serializable]
public class ActionWaitData : ActionData
{
    public ActionWaitData() { type = ActionType.Wait; }
    public float time;
}

[System.Serializable]
public class ActionShowData : ActionData
{
    public ActionShowData() { type = ActionType.Show; }
    public string objectAddress;
    public Vector2 position;
    public SortingLayerField layerField;
    public string layer;
    public int orderInLayer;
    public Transition transition;
    public float time;
}

[System.Serializable]
public class ActionHideData : ActionData
{
    public ActionHideData() { type = ActionType.Hide; }
    public string objectAddress;
    public Transition transition;
    public float time;
}
[System.Serializable]
public class ActionShowDialogueData : ActionData
{
    public ActionShowDialogueData() { type = ActionType.ShowDialogue; }

    public string dialogue;
}
[System.Serializable]
public class ActionEndSequenceData : ActionData
{
    public ActionEndSequenceData() { type = ActionType.EndSequence; }
}
[System.Serializable]
public class ActionLoadSequenceData : ActionData
{
    public ActionLoadSequenceData() { type = ActionType.LoadSequence; }

    public string nextSequence;
}
