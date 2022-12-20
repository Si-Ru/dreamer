using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemaUIManager : MonoBehaviour
{
    public GameObject cinemaUI;
    public GameObject chattingUI;
    public GameObject attendingUI;


    public bool isMonolouge;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i < 6; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if (GameState.PROGRESS == "VICTORY")
        {
     
            gameObject.transform.GetChild(6).gameObject.SetActive(true);

            return;
        
            
        }


        if (GameState.SCRIPT_KEY != "" && gameObject.activeSelf)
        {
            if (GameState.SCRIPT_KEY.Split("_")[1] == "dream")
            {
                gameObject.transform.GetChild(GameState.DAY - 1).gameObject.SetActive(true);
                if (GameState.DAY > 1)
                    gameObject.transform.GetChild(GameState.DAY - 2).gameObject.SetActive(false);
            }
            else
            {
//                cinemaUI.SetActive(false);
            }
        }
        


        if(GameState.SCRIPT_KEY == "day1_bedroom_wakeup" ||
            GameState.SCRIPT_KEY == "day2_bedroom_wakeup"||
            GameState.SCRIPT_KEY == "")
        {
            if (cinemaUI.activeSelf == true)
            {
                cinemaUI.SetActive(false);
                attendingUI.SetActive(true);
                CameraMoving.fixCameraLoc(CameraPositions.BEDROOM_CAMERA_POSITION, CameraPositions.BEDROOM_CAMERA_ROTATION);
                GameState.PROGRESS = "BEDROOM_MORNING";
                

                //if day 1, 2 has wake up script
                if(GameState.SCRIPT_KEY != "")
                {
                    chattingUI.SetActive(true);
                }
                else if(GameState.DAY == 5)
                {
                    if (gameObject.transform.GetChild(5).gameObject.activeSelf != true)
                    {
                        cinemaUI.SetActive(true);
                        GameState.SCRIPT_KEY = "day5_dream_black";
                        gameObject.transform.GetChild(5).gameObject.SetActive(true);
                        chattingUI.SetActive(true);
                    }

                }   
            }
        }
    }
}
