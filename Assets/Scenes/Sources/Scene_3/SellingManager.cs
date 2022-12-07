using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class SellingManager : MonoBehaviour
{
    public GameObject sellingPopup;
    public GameObject customerString;

    public GameObject tiredness;
    public GameObject persuasion;

    public GameObject currentTheme;
    public GameObject customerTheme;

    public GameObject playerSelect;
    public GameObject customerSelect;
    public GameObject playerSelectText;
    public GameObject customerSelectText;

    public GameObject customerImage;

    public GameObject chattingBar;

    private Customer customer;
    private Game game;

    public void SetGame()
    {
        if (customerString.GetComponent<TextMeshProUGUI>().text == "")
            return;

        sellingPopup.SetActive(true);

        //print(customerString.GetComponent<TextMeshProUGUI>().text);
        customer = new Customer(customerString.GetComponent<TextMeshProUGUI>().text);
        game = new Game(customer);
        isFinished = false;
        gameUIRefresh();
    }

    private string[] theme = { "신뢰", "논리", "감정" };
    private string[] Theme = { "신뢰\n(Ethos)", "논리\n(Logos)", "감정\n(Pathos)" };
    private string[] level = { "1레벨", "2레벨", "3레벨" };
    private Color[] colors = { Color.green, Color.blue, Color.red };
    private Color[] textColors = { Color.black, Color.white, Color.white };

    public void gameUIRefresh()
    {
        //yield return null;
        customerImage.GetComponent<RawImage>().texture = (Texture2D)Resources.Load(customer.profileImage);

        tiredness.GetComponentInChildren<Slider>().value = (float)game.currentTired / game.maxTired;
        persuasion.GetComponentInChildren<Slider>().value = (float)game.currentHealth / game.maxHealth;
        currentTheme.GetComponent<TextMeshProUGUI>().text = Theme[game.currentTheme];
        currentTheme.GetComponent<TextMeshProUGUI>().color = colors[game.currentTheme];
        customerTheme.GetComponent<TextMeshProUGUI>().text = Theme[customer.characteristic];
        customerTheme.GetComponent<TextMeshProUGUI>().color = colors[customer.characteristic];

        for (int i = 0; i < 3; i++)
        {
            GameObject.Find(string.Format("PlayerText{0}", i + 1)).GetComponent<TextMeshProUGUI>().text
                = theme[game.playerInventory[i].kind] + "\n" + level[game.playerInventory[i].level];
            GameObject.Find(string.Format("PlayerText{0}", i + 1)).GetComponent<TextMeshProUGUI>().color
                = textColors[game.playerInventory[i].kind];
            GameObject.Find(string.Format("PlayerButton{0}", i + 1)).GetComponent<Image>().color
                = colors[game.playerInventory[i].kind];
        }

        for (int i = 0; i < 3; i++)
        {
            GameObject.Find(string.Format("CustomerText{0}", i + 1)).GetComponent<TextMeshProUGUI>().text
                = theme[game.customerInventory[i].kind];
            GameObject.Find(string.Format("CustomerText{0}", i + 1)).GetComponent<TextMeshProUGUI>().color
                = textColors[game.customerInventory[i].kind];
            GameObject.Find(string.Format("CustomerButton{0}", i + 1)).GetComponent<Image>().color
                = colors[game.customerInventory[i].kind];
        }
    }

    private bool isSelected = false;
    private bool isFinished = false;

    public void selectCommand(int i)
    {
        if (isSelected || isFinished || GameState.IS_PAUSED) return;
        isSelected = true;

        TextMeshProUGUI selectedText = GameObject.Find(string.Format("PlayerText{0}", i + 1)).GetComponent<TextMeshProUGUI>();
        Image selectedBtnImage = GameObject.Find(string.Format("PlayerButton{0}", i + 1)).GetComponent<Image>();

        playerSelect.GetComponent<Image>().color = selectedBtnImage.color;
        playerSelectText.GetComponent<TextMeshProUGUI>().text = selectedText.text;
        playerSelectText.GetComponent<TextMeshProUGUI>().color = selectedText.color;

        System.Random rand = new System.Random();
        int j = rand.Next(3);

        selectedText = GameObject.Find(string.Format("CustomerText{0}", i + 1)).GetComponent<TextMeshProUGUI>();
        selectedBtnImage = GameObject.Find(string.Format("CustomerButton{0}", i + 1)).GetComponent<Image>();

        customerSelect.GetComponent<Image>().color = selectedBtnImage.color;
        customerSelectText.GetComponent<TextMeshProUGUI>().text = selectedText.text + "\n" + level[game.customerInventory[j].level];
        customerSelectText.GetComponent<TextMeshProUGUI>().color = selectedText.color;

        game.selectInventory(i, j);
        gameUIRefresh();

        if (GameState.SCRIPT_KEY == "day1_office_tutorial_1.1")
        {
            chattingBar.SetActive(true);
            GameState.IS_PAUSED = true;
        }
        else if (GameState.SCRIPT_KEY == "day1_office_tutorial_1.2")
        {
            chattingBar.SetActive(true);
            GameState.IS_PAUSED = true;
        }



        if (game.currentHealth == game.maxHealth)
        {
            victory();

            playerSelect.GetComponent<Image>().color = Color.white;
            playerSelectText.GetComponent<TextMeshProUGUI>().text = "";
            customerSelect.GetComponent<Image>().color = Color.white;
            customerSelectText.GetComponent<TextMeshProUGUI>().text = "";

            isFinished = true;
        }
        else if (game.currentTired == game.maxTired)
        {
            lose();

            playerSelect.GetComponent<Image>().color = Color.white;
            playerSelectText.GetComponent<TextMeshProUGUI>().text = "";
            customerSelect.GetComponent<Image>().color = Color.white;
            customerSelectText.GetComponent<TextMeshProUGUI>().text = "";

            isFinished = true;
        }
        

        isSelected = false;
    }

    void victory()
    {

        if (GameState.SCRIPT_KEY == "day1_office_sellingSuccess")
        {
            chattingBar.SetActive(true);
            GameState.IS_PAUSED = true;
        }
        sellingPopup.SetActive(false);
        GameState.IS_POPPED_UP = false;
    }

    void lose()
    {
        if (GameState.SCRIPT_KEY == "day1_office_sellingFailed")
        {
            chattingBar.SetActive(true);
            GameState.IS_PAUSED = true;
        }
        sellingPopup.SetActive(false);
        GameState.IS_POPPED_UP = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.SCRIPT_KEY == "day1_office_sellingFailed" && chattingBar.activeSelf == false)
        {
            lose();

            playerSelect.GetComponent<Image>().color = Color.white;
            playerSelectText.GetComponent<TextMeshProUGUI>().text = "";
            customerSelect.GetComponent<Image>().color = Color.white;
            customerSelectText.GetComponent<TextMeshProUGUI>().text = "";

            isFinished = true;

        }
    }
}
