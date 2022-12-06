using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
using TMPro;

public class CustomerListManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI selectedNumberText;
    public GameObject customerListMakerPopup;
    private int selectedNumber;
    private int[] isSelected;
    private Customer[] customerList;
    public GameObject chattingBar;

    public void OnButtonClick(Button btn)
    {
        string _currentBtnName = EventSystem.current.currentSelectedGameObject.name;
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

        if (Int32.TryParse(_currentBtnName.Substring(8,1), out int _currentBtnNum))
        {
            print(_currentBtnNum);
            _currentBtnNum = _currentBtnNum - 1;
            if (isSelected[_currentBtnNum] == 0)
            {
                if (selectedNumber == customerListMaker.enableCustomerCnt)
                    return;

                var colors = btn.colors;
                colors.normalColor = Color.green;
                colors.highlightedColor = Color.green;
                btn.colors = colors;
                isSelected[_currentBtnNum] = 1;
                selectedNumber++;
            }
            else
            {
                var colors = btn.colors;
                colors.normalColor = new Color(229, 229, 229, 255);
                colors.highlightedColor = new Color(245, 245, 245, 255);
                btn.colors = colors;
                isSelected[_currentBtnNum] = 0;
                selectedNumber--;
            }
        }

        selectedNumberText.text = String.Format("{0} / {1}", selectedNumber, customerListMaker.enableCustomerCnt);
        if(selectedNumber == customerListMaker.enableCustomerCnt)
        {
            selectedNumberText.color = Color.green;
        }
        else
        {
            selectedNumberText.color = Color.white;
        }
    }

    public void SaveCurrentSelectedCustomer()
    {
        if (selectedNumber == customerListMaker.enableCustomerCnt)
        {
            int j = 0;
            for (int i = 0; i < customerListMaker.totalCustomerCnt; i++)
            {

                if (isSelected[i] == 1)
                {
                    customerList[j++] = customerListMaker.customers[i];
                }
            }
            
            customerListMakerPopup.SetActive(false);
            if(GameState.SCRIPT_KEY=="day2_office_tutorial_2"){
                chattingBar.SetActive(true);
            }
        }
    }

    private CustomerListMaker customerListMaker = null;

    // Start is called before the first frame update
    void Start()
    {
        customerListMaker = new CustomerListMaker();
        isSelected = new int[customerListMaker.totalCustomerCnt];
        customerList = new Customer[customerListMaker.enableCustomerCnt];
        //TODO : ui setup based on random customer
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
