using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MonitorClickEvent : MonoBehaviour, IPointerDownHandler
{
    bool isOver = false;
    bool isPopup = false;


    public GameObject chattingBar;
    public GameObject customerListUI;
    public GameObject customerListMakerPopup;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isPopup) return;

        isPopup = true;
        //popup â ����
        customerListUI.SetActive(true);
        customerListMakerPopup.SetActive(true);

        if(GameState.SCRIPT_KEY == "day2_office_tutorial_1"){
            chattingBar.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
