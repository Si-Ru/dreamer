using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CustomerClickEvent : MonoBehaviour
{
    public void OnButtonClick()
    {

    }

    CustomerListMaker customerListMaker = null;

    // Start is called before the first frame update
    void Start()
    {
        customerListMaker = new CustomerListMaker();
        //TODO : ui setup based on random customer
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
