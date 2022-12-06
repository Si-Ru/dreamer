using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.Json;
using System;
using System.IO;
using TMPro;

public class ScriptClass{
    public Dictionary<string, Script> SuperScript;

    public string fileName = "Assets/Scenes/Scripts/tutorialScript.json";


    public ScriptClass(){

        string jsonString = File.ReadAllText(fileName);

        print(jsonString);

        SuperScript = JsonUtility.FromJson< Dictionary<string, Script> >(jsonString);


        //SuperScript = JsonSerializer.Deserialize< Dictionary<string, Script> >(jsonString);
    }

    
}

public class OfficeChattingBar : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Text;



    public ScriptClass script = null;

    // Start is called before the first frame update
    void Start()
    {
        script = new ScriptClass();
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(script != null)
            Text.text = script.SuperScript["day1_dream"].script[0].text;
    }
}
