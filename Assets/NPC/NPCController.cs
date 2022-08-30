using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class NPCController : MonoBehaviour, IPointerClickHandler
{   
    [SerializeField] ScrollDialog Scroll;
    [SerializeField] bool AttachLeft;
    [SerializeField] StoryManager StoryManager;
    [SerializeField] Vector2 PositionWhenFocusIn;

    bool dialogActive;

    private void Awake()
    {
        Scroll.Unscrolled += ScrollDialog_Unscrolled;
    }

    private void OnDestroy()
    {
        Scroll.Unscrolled -= ScrollDialog_Unscrolled;
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
            CameraManager.Instance.FocusIn(PositionWhenFocusIn);
            dialogActive = true;
        }
    }

    void ScrollDialog_Unscrolled()
    {
        StoryManager.LoadStoryChunk();
    }
}
