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
    [SerializeField] TextMeshProUGUI chatterName;

    public GameObject scriptSkipButton;
    public GameObject portrait;

    private int textNum = 0;


    public void scriptSkip(){

        int _currentScriptListLength = CameraMoving.SuperScript[GameState.SCRIPT_KEY].script.Count;

        if(textNum < _currentScriptListLength - 1){
            textNum = textNum + 1;
            GameState.IS_PAUSED = true;
        }
        else{
            GameState.SCRIPT_KEY = CameraMoving.SuperScript[GameState.SCRIPT_KEY].nextStep;
            gameObject.SetActive(false);
            GameState.IS_PAUSED = false;
            textNum = 0;
        }

    }



    // Start is called before the first frame update
    void Start()
    {




        GameState.SCRIPT_KEY = "day1_office_tutorial_0";
        //GameState.SCRIPT_KEY = "day1_office_sellingFailed";
        



    }

    // Update is called once per frame
    void Update()
    {

        /*if(gameObject.activeSelf == true){
            GameState.IS_PAUSED = true;
        }
        else{
            GameState.IS_PAUSED = false;
        }*/

        if (CameraMoving.SuperScript != null)
        {
            portrait.GetComponent<RawImage>().texture = (Texture2D)Resources.Load(CameraMoving.SuperScript[GameState.SCRIPT_KEY].script[textNum].narratorImage);
            Text.text = CameraMoving.SuperScript[GameState.SCRIPT_KEY].script[textNum].text;
            chatterName.text = CameraMoving.SuperScript[GameState.SCRIPT_KEY].script[textNum].narrator;
        }
    }
}
