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
    public GameObject leavingWorkUI;
    public GameObject gotoBedUI;

    private int selectedCount;
    private int[] isSelected;
    private Customer[] customerList;
    private CustomerListMaker customerListMaker = null;
    public GameObject chattingBar;
    public GameObject customerString;
    private bool isCustomerListSetuped = false;
    private bool isCustomerListMakerSetuped = false;

    public void SetupCustomer()
    {
        if (GameState.IS_PAUSED == true) return;
        if (GameState.SCRIPT_KEY == "day5_girlfriend_fight") return;
        //if (GameState.DAY >= 5) return;
        gameObject.SetActive(true);

        customerListMaker = new CustomerListMaker();
        selectedCount = 0;
        isSelected = new int[customerListMaker.totalCustomerCnt];
        customerList = new Customer[customerListMaker.enableCustomerCnt];
        GameState.TODAY_CALLED_CUSTOMER = 0;

        // For tutorial, setup the customer list
        selectedCountText.text = String.Format("0 / {0}", customerListMaker.enableCustomerCnt);
        if (GameState.DAY == 1)
        {
            customerList[0] = new Customer("김은영", "여", "010-xxx-xxxx", 1, 1, 100, 3, "Character/Face/Character_Female1");
            customerList[1] = new Customer("XXX", "남", "010-xxx-xxxx", 1, 5, 1000, 3, "Character/Face/Character_Male10");
        }

        /*customerListPopupSetup();
        if(GameState.DAY >= 2)
            customerListMakerPopupSetup();*/
        isCustomerListSetuped = false;
        isCustomerListMakerSetuped = false;
    }

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
                leavingWorkUI.SetActive(true);
            }

            isCustomerListSetuped = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
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
            customerListPopup.transform.GetChild(i).gameObject.SetActive(true);

            GameObject.Find(String.Format("CustomerList{0}Portrait", i + 1)).GetComponent<RawImage>().texture = 
                (Texture2D)Resources.Load(customerList[i].profileImage);
            GameObject.Find(String.Format("CustomerList{0}Info", i + 1)).GetComponent<TextMeshProUGUI>().text =
                String.Format("이름 : {0}\n성별: {1}\n연락처: {2}\n난이도: {3} 특성: {4}",
                customerList[i].name, customerList[i].sex, customerList[i].phone, (new string('★',customerList[i].difficultyLevel)).PadRight(8),characteristic[customerList[i].characteristic]);
        }
        GameObject.Find("CustomerList_detail").GetComponent<TextMeshProUGUI>().text = "";
    }

    private int maxCustomers = 8;
    private void customerListMakerPopupSetup()
    {
        int customerCnt = customerListMaker.totalCustomerCnt;

        for (int i = customerCnt; i < maxCustomers; i++)
        {
            customerListMakerPopup.transform.GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < customerCnt; i++)
        {
            customerListMakerPopup.transform.GetChild(i).gameObject.SetActive(true);

            Customer _customer = customerListMaker.customers[i];
            GameObject customerObject = GameObject.Find(String.Format("Customer{0}", i + 1));
            customerObject.transform.GetChild(0).GetComponent<RawImage>().texture =
                (Texture2D)Resources.Load(_customer.profileImage);
            GameObject.Find(String.Format("Customer{0}Info", i + 1)).GetComponent<TextMeshProUGUI>().text =
                String.Format("이름 : {0}\n성별: {1}\n연락처: {2}\n난이도: {3} 특성: {4}",
                _customer.name, _customer.sex, _customer.phone, (new string('★', _customer.difficultyLevel)).PadRight(8), characteristic[_customer.characteristic]);
            print(i);
            var btnColor = customerObject.transform.GetChild(1).GetComponent<Button>().colors;
            btnColor.normalColor = new Color(255, 255, 255, 255);
            btnColor.highlightedColor = new Color(245, 245, 245, 255);
            customerObject.transform.GetChild(1).GetComponent<Button>().colors = btnColor;
        }
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
        isCustomerListSetuped = false;


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

    public void LeaveOffice()
    {
        if (GameState.IS_PAUSED == true) return;

        CameraMoving.fixCameraLoc(CameraPositions.DININGROOM_CAMERA_POSITION, CameraPositions.DININGROOM_CAMERA_ROTATION);
        GameState.PROGRESS = "DINING_ROOM";
        leavingWorkUI.SetActive(false);
        gotoBedUI.SetActive(true);

        if (GameState.SCRIPT_KEY != "")
        {
            chattingBar.SetActive(true);
        }
        else if (GameState.DAY == 3)
        {
            GameState.SCRIPT_KEY = "day3_girlfriend";
            chattingBar.SetActive(true);
        }
        else if(GameState.DAY == 4)
        {
            GameState.SCRIPT_KEY = "day4_girlfriend";
            chattingBar.SetActive(true);
        }
        /*
        else {
            GameState.SCRIPT_KEY="dining_room_no_work";
            chattingBar.SetActive(true);
        }
         */
    }

    // Update is called once per frame
    void Update()
    {
        if (customerListPopup.activeSelf == true && isCustomerListSetuped == false)
        {
            customerListPopupSetup();
            isCustomerListSetuped = true;
        }

        if (customerListMakerPopup.activeSelf == true && isCustomerListMakerSetuped == false)
        {
            customerListMakerPopupSetup();
            isCustomerListMakerSetuped = true;
        }

        if(GameState.PROGRESS == "OFFICE" && GameState.TODAY_CALLED_CUSTOMER == customerListMaker.enableCustomerCnt)
        {
            leavingWorkUI.SetActive(true);
        }
    }
}
