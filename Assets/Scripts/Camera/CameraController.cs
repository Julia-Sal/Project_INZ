using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    public float zoomSpeed = 2.0f;
    public float zoomAmount = 1.0f;
    public float defaultZoom = 60.0f;
    private Camera mainCamera;

    private bool isZoomedIn = false;
    private float originalZoom;
    private float targetZoom;
    public float maxZoom;



    private void Start()
    {
        mainCamera = Camera.main;
        originalZoom = mainCamera.fieldOfView;
        targetZoom = originalZoom;
    }

    private float lastTapTime;
    private const float doubleTapTimeThreshold = 0.3f;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (Time.time - lastTapTime <= doubleTapTimeThreshold)
                {
                    // Double tap detected
                    targetZoom = ZoomCamera();
                    isZoomedIn = !isZoomedIn;
                    
                }
                else
                {
                    lastTapTime = Time.time;
                }
            }
        }

        if (mainCamera.fieldOfView != targetZoom)
        {
            mainCamera.fieldOfView = Mathf.MoveTowards(mainCamera.fieldOfView, targetZoom, zoomSpeed);
        }
    }

    private float ZoomCamera()
    {
        if (isZoomedIn)
        {
            return originalZoom;
        }
        else 
        {
            return 30f;
        }
    }
    
}