using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
using TMPro;

public class CustomerListManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI selectedCountText;
    public GameObject customerListMakerPopup;
    public GameObject customerListPopup;
    private int selectedCount;
    private int[] isSelected;
    private Customer[] customerList;
    public GameObject chattingBar;
    public GameObject customerString;

    public void OnButtonClick(Button btn)
    {
        if (GameState.IS_PAUSED) return;
        string _currentBtnName = EventSystem.current.currentSelectedGameObject.name;
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

        if (Int32.TryParse(_currentBtnName.Substring(8,1), out int _currentBtnNum))
        {
            _currentBtnNum = _currentBtnNum - 1;
            if (isSelected[_currentBtnNum] == 0)
            {
                if (selectedCount == customerListMaker.enableCustomerCnt)
                    return;

                var colors = btn.colors;
                colors.normalColor = Color.green;
                colors.highlightedColor = Color.green;
                btn.colors = colors;
                isSelected[_currentBtnNum] = 1;
                selectedCount++;
            }
            else
            {
                var colors = btn.colors;
                colors.normalColor = new Color(229, 229, 229, 255);
                colors.highlightedColor = new Color(245, 245, 245, 255);
                btn.colors = colors;
                isSelected[_currentBtnNum] = 0;
                selectedCount--;
            }
        }

        selectedCountText.text = String.Format("{0} / {1}", selectedCount, customerListMaker.enableCustomerCnt);
        if(selectedCount == customerListMaker.enableCustomerCnt)
        {
            selectedCountText.color = Color.green;
        }
        else
        {
            selectedCountText.color = Color.white;
        }
    }

    public void SaveCurrentSelectedCustomer()
    {
        if (GameState.IS_PAUSED) return;
        if (selectedCount == customerListMaker.enableCustomerCnt)
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
            GameState.IS_POPPED_UP = false;

            if (GameState.SCRIPT_KEY=="day2_office_tutorial_2"){
                chattingBar.SetActive(true);
                GameState.IS_PAUSED = true;
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

        // For tutorial, setup the customer list
        customerList[0] = new Customer("김은영", "여", "010-xxx-xxxx", 1, 1, 100, 3, "Character/Face/Character_Female1");
        customerList[1] = new Customer("XXX", "남", "010-xxx-xxxx", 1, 5, 1000, 3, "Character/Face/Character_Male10");

        //TODO : ui setup based on random customer
        customerListPopupSetup();
    }

    private int maxCustomerList = 3;
    private string[] characteristic = {"신뢰적","논리적", "감성적" };
    private void customerListPopupSetup()
    {

        int customerCnt = customerListMaker.enableCustomerCnt;

        for(int i=customerCnt;i<maxCustomerList;i++)
        {
            customerListPopup.transform.GetChild(i).gameObject.SetActive(false);
        }

        for(int i=0;i<customerCnt;i++)
        {
            GameObject.Find(String.Format("CustomerList{0}Portrait", i + 1)).GetComponent<RawImage>().texture = 
                (Texture2D)Resources.Load(customerList[i].profileImage);
            GameObject.Find(String.Format("CustomerList{0}Info", i + 1)).GetComponent<TextMeshProUGUI>().text =
                String.Format("이름 : {0}\n성별: {1}\n연락처: {2}\n난이도: {3} 특성: {4}",
                customerList[i].name, customerList[i].sex, customerList[i].phone, (new string('★',customerList[i].difficultyLevel)).PadRight(8),characteristic[customerList[i].characteristic]);
        }
        GameObject.Find("CustomerList_detail").GetComponent<TextMeshProUGUI>().text = "";
    }

    public void SelectCustomer(int i)
    {
        if (GameState.IS_PAUSED) return;
        GameObject.Find("CustomerList_detail").GetComponent<TextMeshProUGUI>().text = customerList[i].toString();
    }

    public void SelectCustomerToGame()
    {
        if (GameState.IS_PAUSED || customerString.GetComponent<TextMeshProUGUI>().text == "")
            return;

        customerListPopup.SetActive(false);


        if (GameState.SCRIPT_KEY == "day1_office_tutorial_1.0")
        {
            chattingBar.SetActive(true);
            GameState.IS_PAUSED = true;
        }
        else if (GameState.SCRIPT_KEY == "day1_office_tutorial_2.0")
        {
            chattingBar.SetActive(true);
            GameState.IS_PAUSED = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
