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

    //
    //private int previousTextNum = -1;
    //
    private Dictionary<string, ScriptFile> superScript = null;

    private string tutorialScriptFileName = "Scripts/tutorialScript.json";
    private string mainScriptFileName = "Scripts/mainScript.json";
    //private string tutorialScriptFileName = "Assets/Scenes/Scripts/tutorialScript.json";
    //private string mainScriptFileName = "Assets/Scenes/Scripts/mainScript.json";

    public void scriptSkip(){

        int _currentScriptListLength = superScript[GameState.SCRIPT_KEY].script.Count;

        if(textNum < _currentScriptListLength - 1){
            textNum = textNum + 1;
            GameState.IS_PAUSED = true;
        }
        else{
            GameState.SCRIPT_KEY = superScript[GameState.SCRIPT_KEY].nextStep;

            gameObject.SetActive(false);
            GameState.IS_PAUSED = false;
            textNum = 0;

            if(GameState.TUTORIAL == true && GameState.SCRIPT_KEY == "")
            {
                GameState.TUTORIAL = false;
                loadScript(mainScriptFileName);
            }
        }

    }

    void loadScript(string jsonFile)
    {
        FileStream fileStream = new FileStream(jsonFile, FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string jsonString = Encoding.UTF8.GetString(data);
        superScript = JsonConvert.DeserializeObject<Dictionary<string, ScriptFile>>(jsonString);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        loadScript(tutorialScriptFileName);
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

        if (superScript != null)
        {
            if(superScript[GameState.SCRIPT_KEY].script[textNum].narratorImage == "")
            {
                portrait.GetComponent<RawImage>().texture = (Texture2D)Resources.Load("Character/d_iconemptygravatar");
            }
            else
                portrait.GetComponent<RawImage>().texture = (Texture2D)Resources.Load(superScript[GameState.SCRIPT_KEY].script[textNum].narratorImage);
            Text.text = superScript[GameState.SCRIPT_KEY].script[textNum].text;
            chatterName.text = superScript[GameState.SCRIPT_KEY].script[textNum].narrator;
        }
    }
}
