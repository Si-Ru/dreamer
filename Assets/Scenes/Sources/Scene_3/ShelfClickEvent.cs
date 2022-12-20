using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShelfClickEvent : MonoBehaviour, IPointerDownHandler
{
    private bool isClicked;
    private float cameraSpeed = 0.1f;
    private Vector3 direction = new Vector3(-4.0f, 0.0f, 0.0f);
    private Vector3 cameraPosition = new Vector3(-0.52f, 10.02f, -6.7f);
    private Vector3 cameraRotation = new Vector3(60.0f, 90.0f, 0.0f);

    private Vector3 objectLocation;
    private Vector3 defaultLocation;

    void Start()
    {
        objectLocation = transform.position;
        defaultLocation = transform.position;
        isClicked = false;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (GameState.IS_PAUSED)
            return;

        if (!isClicked)
        {
            objectLocation = defaultLocation + direction;
            //CameraMoving.fixCameraLoc(cameraPosition, cameraRotation);
            
            isClicked = !isClicked;
        }
        else if (isClicked)
        {
            objectLocation = defaultLocation;
            //CameraMoving.freeCameraLoc();
            isClicked = !isClicked;
        }
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, objectLocation, 1.5f*cameraSpeed);
    }
}
