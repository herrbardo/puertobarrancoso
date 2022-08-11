using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    #region Properties

    [Header("Components")]
    [SerializeField] CinemachineVirtualCamera VirtualCamera;
    [SerializeField] GameObject PivotCamera;
    [Header("Parameters")]
    [SerializeField] float ZoomDuration;
    [SerializeField] float MinOrthographicSize;
    [SerializeField] float MaxOrthographicSize;
    [SerializeField] float MoveCameraXOffset;
    [SerializeField] float MoveDuration;

    #endregion

    #region Singleton

    public static CameraManager Instance;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    #endregion

    bool moveFinished;
    bool zoomFinished;
    bool zooming;

    private void Update()
    {
        CheckFinishedRoutines();
    }

    public void FocusIn(Vector2 targetPosition)
    {
        if(zooming)
            return;
        
        zooming = true;
        zoomFinished = moveFinished = false;
        StartCoroutine(MoveCamera(targetPosition));
        StartCoroutine(Zoom(true));
    }

    public void FocusOut()
    {
        if(zooming)
            return;

        zooming = true;
        zoomFinished = moveFinished = false;
        StartCoroutine(MoveCamera(new Vector2(0f, 0f)));
        StartCoroutine(Zoom(false));
    }

    IEnumerator MoveCamera(Vector2 targetPosition)
    {
        float startX = PivotCamera.transform.position.x;
        float targetX = targetPosition.x;
        float startY = PivotCamera.transform.position.y;
        float targetY = targetPosition.y;
        float currentTime = 0;

        while (currentTime < MoveDuration)
        {
            currentTime += Time.deltaTime;
            float x = Mathf.Lerp(startX, targetX, currentTime / MoveDuration);
            float y = Mathf.Lerp(startY, targetY, currentTime / MoveDuration);
            PivotCamera.transform.position = new Vector3(x, y, PivotCamera.transform.position.z);
            yield return null;
        }
        
        moveFinished = true;
        yield return null;
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

    void CheckFinishedRoutines()
    {
        if(!zooming)
            return;

        if(zoomFinished && moveFinished)
        {
            zooming = false;
            zoomFinished = moveFinished = false;
        }
    }
}
