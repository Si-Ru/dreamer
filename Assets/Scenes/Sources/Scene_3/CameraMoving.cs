using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.IO;
using Newtonsoft.Json;


public class CameraMoving : MonoBehaviour
{
    private static Vector3 CURRENT_CAMERA_POSITION;
    private static Vector3 CURRENT_CAMERA_ROTATION;

    

    public static void fixCameraLoc(Vector3 targetCameraPos, Vector3 targetCameraRot)
    {
        CURRENT_CAMERA_POSITION = targetCameraPos;
        CURRENT_CAMERA_ROTATION = targetCameraRot;
    }

    void Start() {

    }

    void Update()
    {
        if (GameState.IS_PAUSED)
            return;
        
        Camera.main.transform.position = CURRENT_CAMERA_POSITION;
        Camera.main.transform.eulerAngles = CURRENT_CAMERA_ROTATION;
    }
}
