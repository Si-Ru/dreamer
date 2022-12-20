using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MonitorClickEvent : MonoBehaviour, IPointerDownHandler
{
    public GameObject chattingBar;
    public GameObject customerListUI;
    public GameObject customerListMakerPopup;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (GameState.IS_POPPED_UP || GameState.DAY == 1 || GameState.IS_PAUSED) return;

        GameState.IS_POPPED_UP= true;

        customerListUI.SetActive(true);
        customerListMakerPopup.SetActive(true);

        if(GameState.SCRIPT_KEY == "day2_office_tutorial_1"){
            chattingBar.SetActive(true);
            GameState.IS_PAUSED = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
