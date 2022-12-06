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
    private static Vector3 TARGET_CAMERA_POSITION;
    private static Vector3 TARGET_CAMERA_ROTATION;
    private static Vector3 ORIGIN_CAMERA_POSITION;
    private static Vector3 ORIGIN_CAMERA_ROTATION;

    private static bool DRAGGABLE;

    private float cameraDragspeed = -3.5f;
    private float cameraMoveSpeed = 0.1f;

    private float x;
    private float y;
    private Vector3 rotateValue;

    // 
    private static string fileName = "Assets/Scenes/Scripts/tutorialScript.json";
    public static Dictionary<string, ScriptFile> SuperScript = null;
    //

    public static void fixCameraLoc(Vector3 targetCameraPos, Vector3 targetCameraRot)
    {
        DRAGGABLE = false;
        TARGET_CAMERA_POSITION = targetCameraPos;
        TARGET_CAMERA_ROTATION = targetCameraRot;
    }

    public static void freeCameraLoc()
    {
        DRAGGABLE = true;
        TARGET_CAMERA_POSITION = ORIGIN_CAMERA_POSITION;
        TARGET_CAMERA_ROTATION = ORIGIN_CAMERA_ROTATION;
    }

    void Start() {
        DRAGGABLE = true;
        ORIGIN_CAMERA_POSITION = Camera.main.transform.position;
        ORIGIN_CAMERA_ROTATION = Camera.main.transform.eulerAngles;

        TARGET_CAMERA_POSITION = Camera.main.transform.position;
        TARGET_CAMERA_ROTATION = Camera.main.transform.eulerAngles;

        //Script 받아오기.

        FileStream fileStream = new FileStream(fileName, FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string jsonString = Encoding.UTF8.GetString(data);
        SuperScript = JsonConvert.DeserializeObject<Dictionary<string, ScriptFile>>(jsonString);



    }

    bool checkCameraLoc()
    {
        return ORIGIN_CAMERA_POSITION == Camera.main.transform.position && ORIGIN_CAMERA_ROTATION == Camera.main.transform.eulerAngles;
    }

    void Update()
    {
        if (GameState.IS_PAUSED)
            return;

        if (DRAGGABLE && checkCameraLoc() && Input.GetMouseButton(0))
        {
            y = Input.GetAxis("Mouse X");
            x = Input.GetAxis("Mouse Y");
            rotateValue = new Vector3(x * cameraDragspeed, y * -cameraDragspeed, 0);

            Vector3 _temp = transform.eulerAngles - rotateValue;
            _temp[0] = Mathf.Clamp(_temp[0], 1, 28);
            _temp[1] = Mathf.Clamp(_temp[1], 14, 88);

            transform.eulerAngles = _temp;
            
            ORIGIN_CAMERA_ROTATION = Camera.main.transform.eulerAngles;
        }
        else if (!DRAGGABLE || !checkCameraLoc())
        {
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, TARGET_CAMERA_POSITION, cameraMoveSpeed);
            Camera.main.transform.eulerAngles = Vector3.MoveTowards(Camera.main.transform.eulerAngles, TARGET_CAMERA_ROTATION, 8 * cameraMoveSpeed);
        }
    }
}
