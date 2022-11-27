using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClickEvent : MonoBehaviour
{

    public GameObject open_button;
    public GameObject close_button;


    public void openBar(){
        gameObject.SetActive(true);
        open_button.SetActive(false);

        GameState.isPaused = true;
    }
    
    public void closeBar(){
        gameObject.SetActive(false);
        open_button.SetActive(true);

        GameState.isPaused = false;
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
