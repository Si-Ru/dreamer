using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickEvent : MonoBehaviour
{

    public GameObject open_button;
    public GameObject close_button;


    public void openBar(){
        gameObject.SetActive(true);
        open_button.SetActive(false);
    }
    
    public void closeBar(){
        gameObject.SetActive(false);
        open_button.SetActive(true);

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
