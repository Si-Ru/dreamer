using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShelfClickEvent : MonoBehaviour, IPointerDownHandler
{
    private bool st;
    private float speed = 0.1f;
    private Vector3 direction = new Vector3(-4.0f, 0.0f, 0.0f);
    private Vector3 objectLocation;
    private Vector3 defaultLocation;

    private Vector3 cameraPos = new Vector3(-0.52f, 10.02f, -6.7f);
    private Vector3 cameraRot = new Vector3(60.0f, 90.0f, 0.0f);

    void Start()
    {
        objectLocation = transform.position;
        defaultLocation = transform.position;
        st = true;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (GameState.isPaused)
            return;

        if (st)
        {
            objectLocation = defaultLocation + direction;
            CameraMoving.fixCameraLoc(cameraPos, cameraRot);
            
            st = !st;
        }
        else if (!st)
        {
            objectLocation = defaultLocation;
            CameraMoving.freeCameraLoc();
            st = !st;
        }
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, objectLocation, 1.5f*speed);
    }
}
