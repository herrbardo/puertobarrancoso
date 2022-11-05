using UnityEngine;

public enum TransitionIn
{
    None = 0,
    FadeIn = 1,
}

public enum TransitionOut
{
    None = 0,
    FadeOut = 1,
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
    Pause = 7,
    HideDialogue = 8,
    PlaySoundEffect = 9,
    PlayMusic = 10,
    PlayAnimation = 11,
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

public enum PrefabType
{
    Gameobject,
    Sprite
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
    public int objectCopyIndex;
    public PrefabType PrefabType;
    public Vector2 position;
    public SortingLayerField layerField;
    public string layer;
    public int orderInLayer;
    public TransitionIn transition;
    public float time;
    public string ObjectAddress => objectAddress + objectCopyIndex;
}

[System.Serializable]
public class ActionHideData : ActionData
{
    public ActionHideData() { type = ActionType.Hide; }
    public string objectAddress;
    public int objectCopyIndex = 0;
    public TransitionOut transition;
    public float time;

    public string ObjectAddress => objectAddress + objectCopyIndex;

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
[System.Serializable]
public class ActionPauseData : ActionData
{
    public ActionPauseData() { type = ActionType.Pause; }

}

[System.Serializable]
public class ActionHideDialogueData: ActionData
{
    public ActionHideDialogueData() { type = ActionType.HideDialogue; }

}

[System.Serializable]
public class ActionPlaySoundEffectData : ActionData
{
    public ActionPlaySoundEffectData() { type = ActionType.PlaySoundEffect; }

}

[System.Serializable]
public class ActionPlayMusicData : ActionData
{
    public ActionPlayMusicData() { type = ActionType.PlayMusic; }

}

[System.Serializable]
public class ActionPlayAnimationData : ActionData
{
    public ActionPlayAnimationData() { type = ActionType.PlayAnimation; }

}