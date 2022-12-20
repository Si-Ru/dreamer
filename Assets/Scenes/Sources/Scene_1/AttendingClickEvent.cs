using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttendingClickEvent : MonoBehaviour
{
    public GameObject attendingUI;
    public GameObject chattingUI;
    public GameObject cinemaUI;

    

    public void AttendingBtnClickEvent()
    {
        if (GameState.IS_PAUSED == true) return;
        if (GameState.SCRIPT_KEY == "day5_girlfriend_fight") return;

        if (GameState.DAY == 5)
        {
            GameState.SCRIPT_KEY = "day5_girlfriend";
            chattingUI.SetActive(true);
            //attendingUI.SetActive(false);
            return;
        }

        CameraMoving.fixCameraLoc(CameraPositions.OFFICE_CAMERA_POSITION, CameraPositions.OFFICE_CAMERA_ROTATION);
        GameState.PROGRESS = "OFFICE";
        attendingUI.SetActive(false);

        if (GameState.SCRIPT_KEY != "")
        {
            chattingUI.SetActive(true);
        }
        /*if(GameState.DAY == 5 && GameState.SCRIPT_KEY == "")
        {
            GameState.SCRIPT_KEY = "day5_girlfriend";
            //chattingBar.SetActive(true);
        }*/
    }

    void Update()
    {
        if (GameState.SCRIPT_KEY == "day5_monolouge")
        {
            cinemaUI.SetActive(true);
            chattingUI.SetActive(true);
            GameObject.Find("AttendingTxt").GetComponent<TextMeshProUGUI>().text = "Àü Åõ !";
        }
        else if(GameState.SCRIPT_KEY == "day5_girlfriend_fight")
        {
            cinemaUI.SetActive(false);
        }
    }
}
