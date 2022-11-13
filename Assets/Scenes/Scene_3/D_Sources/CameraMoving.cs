using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMoving : MonoBehaviour
{
    private float cameraDragspeed = -3.5f;
    private float cameraMoveSpeed = 0.1f;

    private static bool draggable;
    private static Vector3 targetCameraPosition;
    private static Vector3 targetCameraRotation;
    private static Vector3 originCameraPosition;
    private static Vector3 originCameraRotation;

    private static Vector3 temp;


    private float x;
    private float y;
    private Vector3 rotateValue;

    public static void fixCameraLoc(Vector3 targetCameraPos, Vector3 targetCameraRot)
    {
        draggable = false;
        targetCameraPosition = targetCameraPos;
        targetCameraRotation = targetCameraRot;
    }

    public static void freeCameraLoc()
    {
        draggable = true;
        targetCameraPosition = originCameraPosition;
        targetCameraRotation = originCameraRotation;
    }

    void Start() {
        draggable = true;
        originCameraPosition = Camera.main.transform.position;
        originCameraRotation = Camera.main.transform.eulerAngles;

        targetCameraPosition = Camera.main.transform.position;
        targetCameraRotation = Camera.main.transform.eulerAngles;
    }

    bool checkCameraLoc()
    {
        return originCameraPosition == Camera.main.transform.position && originCameraRotation == Camera.main.transform.eulerAngles;
    }

    void Update()
    {
        if (draggable && checkCameraLoc() && Input.GetMouseButton(0))
        {
            
            y = Input.GetAxis("Mouse X");
            x = Input.GetAxis("Mouse Y");
            rotateValue = new Vector3(x * cameraDragspeed, y * -cameraDragspeed, 0);

            temp = transform.eulerAngles - rotateValue;
            temp[0] = Mathf.Clamp(temp[0], 1, 28);
            temp[1] = Mathf.Clamp(temp[1], 14, 88);

            transform.eulerAngles = temp;

            
            //Camera.main.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * cameraDragspeed, 0), Space.World);
            originCameraRotation = Camera.main.transform.eulerAngles;
            Debug.Log(originCameraRotation);
        }
        else if (!draggable || !checkCameraLoc())
        {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, targetCameraPosition, cameraMoveSpeed);
            Camera.main.transform.eulerAngles = Vector3.MoveTowards(Camera.main.transform.eulerAngles, targetCameraRotation, 8 * cameraMoveSpeed);
        }
    }
}
