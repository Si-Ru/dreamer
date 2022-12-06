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

    private string fileName = "Assets/Scenes/Scripts/tutorialScript.json";

    public Dictionary<string, ScriptFile> SuperScript = null;

    // Start is called before the first frame update
    void Start()
    {
        string startScript = "day1_dream";
        // read file stream
        FileStream fileStream = new FileStream(fileName, FileMode.Open);
        byte[] data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string jsonString = Encoding.UTF8.GetString(data);
        SuperScript = JsonConvert.DeserializeObject<Dictionary<string, ScriptFile>>(jsonString);
    }

    // Update is called once per frame
    void Update()
    {   
        if(SuperScript != null)
            Text.text = SuperScript["day1_dream"].script[0].text;
    }
}
