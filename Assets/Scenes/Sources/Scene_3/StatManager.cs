using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class StatManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI selectedCountText;
    [SerializeField] TextMeshProUGUI todayBookText;

    public Button inventoryBtn;
    public Button customerCntBtn;
    public Button searchPowBtn;
    public GameObject statUI;
    public GameObject investCanvas1;
    public GameObject investCanvas2;

    private int[] _isSelected = new int[5];
    private int _selectedCount = 0;
    private int _todayBookNum = 0;
    private string[] _todayBookText = { "½Å·Ú", "³í¸®", "°¨Á¤" };

    public void OnButtonClick(Button btn)
    {
        if (GameState.IS_PAUSED) return;
        string _currentBtnName = EventSystem.current.currentSelectedGameObject.name;
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

        if (_selectedCount == GameState.STAT_POINT)
            return;

        if (Int32.TryParse(_currentBtnName.Substring(0,1), out int _currentBtnNum))
        {
            _currentBtnNum = _currentBtnNum - 1;
            if (_isSelected[_currentBtnNum] == 0)
            {
                var colors = btn.colors;
                colors.normalColor = Color.green;
                colors.highlightedColor = Color.green;
                btn.colors = colors;
                _isSelected[_currentBtnNum] = 1;
                _selectedCount++;
            }
            else
            {
                var colors = btn.colors;
                colors.normalColor = new Color(229, 229, 229, 255);
                colors.highlightedColor = new Color(245, 245, 245, 255);
                btn.colors = colors;
                _isSelected[_currentBtnNum] = 0;
                _selectedCount--;
            }
        }

        selectedCountText.text = String.Format("{0} / {1}", _selectedCount, GameState.STAT_POINT);
        if (_selectedCount == GameState.STAT_POINT)
        {
            selectedCountText.color = Color.green;
        }
        else
        {
            selectedCountText.color = Color.white;
        }
    }

    public void SelectBtnClickEvent()
    {
        if (GameState.IS_PAUSED) return;
        if (_selectedCount != GameState.STAT_POINT) return; // ´õ °ñ¶ó!

        if(_isSelected[0]==1)
        {
            if(_todayBookNum == 0)
            {
                Player.getPlayer().ethosPow += 2;
            }
            else if (_todayBookNum == 1)
            {
                Player.getPlayer().logosPow += 2;
            }
            else
            {
                Player.getPlayer().pathosPow += 2;
            }
        }

        if(_isSelected[1] == 1)
        {
            Player.getPlayer().health += 10;
        }

        if (_isSelected[2] == 1)
        {
            Player.getPlayer().inventory++;
        }

        if (_isSelected[3] == 1)
        {
            Player.getPlayer().searchPow++;
        }

        if (_isSelected[4] == 1)
        {
            Player.getPlayer().customerCnt++;
        }

        GameState.DAY++;
        statUI.SetActive(false);
        investCanvas1.SetActive(true);
        investCanvas2.SetActive(true);
        GameState.STAT_POINT = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        loadTodayBook();
    }

    private void loadTodayBook()
    {
        System.Random rand = new System.Random();
        _todayBookNum = rand.Next(3);
        todayBookText.text = String.Format("Ã¥ ÀÐ±â\n¿À´ÃÀÇ Ã¥ : {0}", _todayBookText[_todayBookNum]);
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.getPlayer().inventory == 5)
        {
            inventoryBtn.interactable = false;
        }
        if (Player.getPlayer().searchPow == 10)
        {
            searchPowBtn.interactable = false;
        }
    }
}
