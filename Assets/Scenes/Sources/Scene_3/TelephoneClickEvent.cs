using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TelephoneClickEvent : MonoBehaviour, IPointerDownHandler
{
    bool isPopup = false;

    public GameObject customerListUI;
    public GameObject customerListPopup;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isPopup) return;

        isPopup = true;
        //popup Ã¢ ¶ç¿ì±â
        customerListUI.SetActive(true);
        customerListPopup.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
