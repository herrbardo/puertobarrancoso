using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class NPCController : MonoBehaviour, IPointerClickHandler
{   
    [SerializeField] CinemachineVirtualCamera VirtualCamera;
    [SerializeField] GameObject PivotCamera;
    [SerializeField] GameObject ScrollDialogPrefab;
    [SerializeField] ScrollDialog Scroll;
    [SerializeField] GameObject DialogSystemPrefab;
    [SerializeField] GameObject PivotScroll;
    [SerializeField] Transform CanvasUI;
    [SerializeField] float ZoomDuration;
    [SerializeField] float MinOrthographicSize ;
    [SerializeField] float MaxOrthographicSize;
    [SerializeField] float MoveCameraXOffset;
    [SerializeField] bool MoveToLeft;
    [SerializeField] float MoveDuration;

    bool zoomIn;
    bool zooming;
    bool zoomFinished;
    bool moveFinished;

    private void Start()
    {
        zoomFinished = moveFinished = true;
    }

    private void Update()
    {
        CheckFinishedRoutines();
    }

    public void OnPointerClick (PointerEventData eventData)
    {
        ZoomIn();
    }

    void ZoomIn()
    {
        if(!zoomFinished || !moveFinished)
            return;
        zoomFinished = false;
        moveFinished = false;
        zooming = true;
        zoomIn = true;
        StartCoroutine(Zoom(true));
        StartCoroutine(MoveCamera(MoveToLeft));
    }

    void CreateDialogSystem()
    {
        Scroll.Show();
        ScrollDialog scrollDialog = Scroll.GetComponent<ScrollDialog>();
        scrollDialog.AddDialogLine("Hola MONDO");
    }

    IEnumerator Zoom(bool zoomIn)
    {
        float startSize = VirtualCamera.m_Lens.OrthographicSize;
        float limitSize = (zoomIn) ? MinOrthographicSize : MaxOrthographicSize;
        float currentTime = 0;

        while (currentTime < ZoomDuration)
        {
            currentTime += Time.deltaTime;
            VirtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(startSize, limitSize, currentTime / ZoomDuration);
            yield return null;
        }

        zoomFinished = true;
        yield return null;
    }

    IEnumerator MoveCamera(bool moveIn)
    {
        float startX = PivotCamera.transform.position.x;
        float targetX = 0f;
        float currentTime = 0;

        if((moveIn && MoveToLeft)||(!moveIn && !MoveToLeft))
            targetX = startX - MoveCameraXOffset;
        else if((moveIn && !MoveToLeft) || (!moveIn && MoveToLeft))
            targetX = startX + MoveCameraXOffset;

        while (currentTime < MoveDuration)
        {
            currentTime += Time.deltaTime;
            float x = Mathf.Lerp(startX, targetX, currentTime / MoveDuration);
            PivotCamera.transform.position = new Vector3(x,PivotCamera.transform.position.z, PivotCamera.transform.position.z);
            yield return null;
        }

        moveFinished = true;
        yield return null;
    }

    void CheckFinishedRoutines()
    {
        if(!zooming)
            return;

        if(zoomFinished && moveFinished)
        {
            zooming = false;

            if(zoomIn)
                CreateDialogSystem();
        }
    }
}
