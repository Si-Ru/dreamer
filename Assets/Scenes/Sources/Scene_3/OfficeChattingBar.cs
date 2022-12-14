using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using TMPro;

public class OfficeChattingBar : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Text;

    public GameObject scriptSkipButton;

    private int textNum = 0;


    public void scriptSkip(){

        int _currentScriptListLength = CameraMoving.SuperScript[GameState.SCRIPT_KEY].script.Count;

        if(textNum < _currentScriptListLength - 1){
            textNum = textNum + 1;
        }
        else{
            GameState.SCRIPT_KEY = CameraMoving.SuperScript[GameState.SCRIPT_KEY].nextStep;
            gameObject.SetActive(false);
            textNum = 0;
        }

    }



    // Start is called before the first frame update
    void Start()
    {
    

        GameState.SCRIPT_KEY = "day2_office_tutorial_0";


    }

    // Update is called once per frame
    void Update()
    {   
        
        if(gameObject.activeSelf == true){
            GameState.IS_PAUSED = true;
        }
        else{
            GameState.IS_PAUSED = false;
        }

        if(CameraMoving.SuperScript != null)
            Text.text = CameraMoving.SuperScript[GameState.SCRIPT_KEY].script[textNum].text;
    }
}
