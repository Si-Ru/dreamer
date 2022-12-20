using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIManager : MonoBehaviour
{
    public GameObject mainUI;
    public GameObject cinemaUI;
    public GameObject startBtn;
    public GameObject exitBtn;
    public GameObject chattingUI;

    public void StartGame()
    {
        GameState.SCRIPT_KEY = "day1_dream";
        GameState.DAY = 1;
        GameState.TUTORIAL = true;
        GameState.PROGRESS = "CINEMA";

        cinemaUI.SetActive(true);
        chattingUI.SetActive(true);
        mainUI.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
