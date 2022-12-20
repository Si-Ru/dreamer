using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClickEvent : MonoBehaviour
{

    public GameObject openButton;
    public GameObject closeButton;


    public void openBar(){
        gameObject.SetActive(true);
        openButton.SetActive(false);

        GameState.IS_PAUSED = true;
    }
    
    public void closeBar(){
        gameObject.SetActive(false);
        openButton.SetActive(true);

        GameState.IS_PAUSED = false;
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
