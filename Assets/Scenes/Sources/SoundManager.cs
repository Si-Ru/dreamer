using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{


    public AudioSource BGM;

    private static SoundManager instance = null;

    private string key;
    private string chatter;

    private bool previousChatting = false;
    private int dayAlarm = 0;


    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(BGM);
            return;
        }
        if (instance == this) return;
        Destroy(BGM);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        key = gameObject.name;
        BGM = GetComponent<AudioSource>();

        BGM.Play();
    }


    public void Talk()
    {
        
        BGM.Play();
    }

    // Update is called once per frame
    void Update()
    {

        if (key == "ChattingUI")
        {
            if (gameObject.transform.GetChild(0).gameObject.activeSelf == true)
            {
                if (previousChatting != true && BGM.isPlaying != true)
                {
                    BGM.Play();
                    previousChatting = true;
                }

            }
            else
            {
                BGM.Stop();
                previousChatting = false;
            }
        }

        else if (key.Split("_")[1] == "Office")
        {
            if (GameState.PROGRESS == "OFFICE")
            {
                if (BGM.isPlaying != true)
                {
                    BGM.Play();
                }
            }
            else
            {
                BGM.Stop();
            }
        }

        else if (key.Split("_")[1] == "Kitchen") {
            if (GameState.PROGRESS == "DINING_ROOM")
            {
                if (BGM.isPlaying != true)
                {
                    BGM.Play();
                }
            }
            else
            {
                BGM.Stop();
            }
        }

        else if (key.Split("_")[1] == "BedRoom")
        {

            if (GameState.DAY == 5)
            {
                BGM.Stop();
            }
            else
            {
                if (GameState.PROGRESS == "BEDROOM_MORNING")
                {
                    if (GameState.DAY != dayAlarm && BGM.isPlaying != true)
                    {
                        BGM.Play();
                        dayAlarm = GameState.DAY;
                    }
                }
                else
                {
                    BGM.Stop();
                }
            }
            
        }


        







    }
}
