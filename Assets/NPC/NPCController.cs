using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class NPCController : MonoBehaviour, IPointerClickHandler
{ 
    [SerializeField] bool AttachLeft;
    [SerializeField] StoryManager StoryManager;
    [SerializeField] Vector2 PositionWhenFocusIn;
    [SerializeField] string Name;

    bool dialogActive;

    private void Start()
    {
        ScrollDialog.Instance.Unscrolled += ScrollDialog_Unscrolled;
    }

    private void OnDestroy()
    {
        ScrollDialog.Instance.Unscrolled -= ScrollDialog_Unscrolled;
    }

    public void OnPointerClick (PointerEventData eventData)
    {
        if(dialogActive)
        {
            ScrollDialog.Instance.Roll();
            CameraManager.Instance.FocusOut();
            dialogActive = false;
        }
        else
        {
            if(AttachLeft)
                ScrollDialog.Instance.AttachLeft();
            else
                ScrollDialog.Instance.AttachRight();

            ScrollDialog.Instance.Show();
            ScrollDialog.Instance.FilterBySpeaker(Name);
            ScrollDialog.Instance.ScrollToBottom(true);
            CameraManager.Instance.FocusIn(PositionWhenFocusIn);
            dialogActive = true;
            NPCEvents.GetInstance().OnNPCSelected(this.Name);
        }
    }

    void ScrollDialog_Unscrolled()
    {
        StoryManager.LoadStoryChunk();
    }
}
