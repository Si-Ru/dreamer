using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TelephoneClickEvent : MonoBehaviour, IPointerDownHandler
{
    public GameObject customerListUI;
    public GameObject customerListPopup;

    public GameObject chattingBar;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (GameState.IS_POPPED_UP || GameState.IS_PAUSED) return;

        print(GameState.SCRIPT_KEY);
        GameState.IS_POPPED_UP = true;

        if (GameState.SCRIPT_KEY== "day1_office_customerList1")
        {
            chattingBar.SetActive(true);
            GameState.IS_PAUSED = true;
        }
        if (GameState.SCRIPT_KEY == "day1_office_customerList2")
        {
            chattingBar.SetActive(true);
            GameState.IS_PAUSED = true;
        }

        //popup Ã¢ ¶ç¿ì±â
        customerListUI.SetActive(true);
        customerListPopup.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
