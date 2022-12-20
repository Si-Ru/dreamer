using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class GameState {

    public static int DAY=0;
    public static bool TUTORIAL = true;
    
// main -> cinema(dream) -> bedroom_morining -> office -> dining room -> bedroom_night -> cinema(dream)
    public static string PROGRESS = "";
    public static int STAT_POINT = 0;

    public static string SCRIPT_KEY = "";

    public static bool IS_PAUSED = false;
    public static bool IS_POPPED_UP = false;

    public static int TODAY_CALLED_CUSTOMER = 0;
}