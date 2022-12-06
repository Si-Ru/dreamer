using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.Json;


public class SubScript{
    public string narrator;
    public string text;
    public string narrator_image;
}

public class Script{
    public IList<SubScript> script;
    public string nextStep;
}


/*
Dictionary<string, Script> SuperScript;

string fileName = "../Scripts/tutorialScript.json";
string jsonString = File.ReadAllText(fileName);
SuperScript = JsonSerializer.Deserialize< Dictionary<string, Script> >(jsonString);
*/






