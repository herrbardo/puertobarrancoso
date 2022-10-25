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
    Characters,
    ObjectsFront,
    Dialogue,
    Foreground,

}

[System.Serializable]
public abstract class Action
{
    public ActionType type { get; set; }

    public T GetAction<T>() where T: Action
    {
        return (T)this;
    }
    //public bool WaitForNext;
}

[System.Serializable]
public class ActionWait : Action
{
    public ActionWait() { type = ActionType.Wait; }
    public float time;
}

[System.Serializable]
public class ActionShow : Action
{
    public ActionShow() { type = ActionType.Show; }
    public string objectAddress;
    public Vector2 position;
    public SortingLayerField layerField;
    public string layer;
    public int orderInLayer;
    public Transition transition;
    public float time;
}

[System.Serializable]
public class ActionHide : Action
{
    public ActionHide() { type = ActionType.Hide; }
    public string objectAddress;
    public Transition transition;
    public float time;
}
[System.Serializable]
public class ActionShowDialogue : Action
{
    public ActionShowDialogue() { type = ActionType.ShowDialogue; }

    public string dialogue;
}
[System.Serializable]
public class ActionEndSequence : Action
{
    public ActionEndSequence() { type = ActionType.EndSequence; }
}
[System.Serializable]
public class ActionLoadSequence : Action
{
    public ActionLoadSequence() { type = ActionType.LoadSequence; }

    public string nextSequence;
}
