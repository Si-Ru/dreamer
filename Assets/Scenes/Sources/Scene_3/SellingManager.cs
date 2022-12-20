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
    public GameObject cinemaUI;

    private Customer customer;
    private Game game;

    public void LastDance()
    {
        if (GameState.SCRIPT_KEY != "day5_girlfriend_fight") return;

        GameState.PROGRESS = "FIGHT";

        sellingPopup.SetActive(true);
        customer = new Customer();
        customer.name = "백서아";
        customer.sex = "여";
        customer.phone = "010-xxx-xxxx";
        customer.characteristic = 2;
        customer.difficultyLevel = 5;
        customer.health = 120;
        customer.inventory = 5;
        customer.profileImage = "Character/Face/Character_Female5";
        game = new Game(customer);
        isFinished = false;
        gameUIRefresh();

        chattingBar.SetActive(true);
    }

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
    private string[] images = { "UI_Icons/SellingButton_ethos", "UI_Icons/SellingButton_logos", "UI_Icons/SellingButton_pathos" };
    private Color[] textColors = { Color.black, Color.white, Color.white };

    public void gameUIRefresh()
    {
        //yield return null;
        print(customer.profileImage);
        customerImage.GetComponent<RawImage>().texture = (Texture2D)Resources.Load(customer.profileImage);

        tiredness.GetComponentInChildren<Slider>().value = (float)game.currentTired / game.maxTired;
        persuasion.GetComponentInChildren<Slider>().value = (float)game.currentHealth / game.maxHealth;
        currentTheme.GetComponent<TextMeshProUGUI>().text = Theme[game.currentTheme];
        currentTheme.GetComponent<TextMeshProUGUI>().color = colors[game.currentTheme];
        customerTheme.GetComponent<TextMeshProUGUI>().text = Theme[customer.characteristic];
        customerTheme.GetComponent<TextMeshProUGUI>().color = colors[customer.characteristic];

        for (int i = 0; i < game.player.inventory; i++)
        {
            GameObject.Find("SellingPanel").transform.GetChild(i).gameObject.SetActive(true);

            GameObject.Find(string.Format("PlayerText{0}", i + 1)).GetComponent<TextMeshProUGUI>().text
                = theme[game.playerInventory[i].kind] + "\n" + level[game.playerInventory[i].level];
            GameObject.Find(string.Format("PlayerText{0}", i + 1)).GetComponent<TextMeshProUGUI>().color
                = textColors[game.playerInventory[i].kind];
            GameObject.Find(string.Format("PlayerButton{0}", i + 1)).GetComponent<Image>().sprite
                = Resources.Load<Sprite>(images[game.playerInventory[i].kind]);
        }
        for (int i = game.player.inventory; i < 5; i++) 
        {
            GameObject.Find("SellingPanel").transform.GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < game.customer.inventory; i++)
        {
            GameObject.Find("SellingPanel").transform.GetChild(i+5).gameObject.SetActive(true);

            GameObject.Find(string.Format("CustomerText{0}", i + 1)).GetComponent<TextMeshProUGUI>().text
                = theme[game.customerInventory[i].kind];
            GameObject.Find(string.Format("CustomerText{0}", i + 1)).GetComponent<TextMeshProUGUI>().color
                = textColors[game.customerInventory[i].kind];
            GameObject.Find(string.Format("CustomerButton{0}", i + 1)).GetComponent<Image>().color
                = colors[game.customerInventory[i].kind];
        }
        for (int i = game.customer.inventory; i < 5; i++)
        {
            GameObject.Find("SellingPanel").transform.GetChild(i+5).gameObject.SetActive(false);
        }
    }

    private bool isSelected = false;
    private bool isFinished = false;

    public void selectCommand(int i)
    {
        if (isSelected || isFinished || GameState.IS_PAUSED) return;
        isSelected = true;

        playerSelect.GetComponent<Image>().sprite = Resources.Load<Sprite>(images[game.playerInventory[i].kind]);
        playerSelectText.GetComponent<TextMeshProUGUI>().text = theme[game.playerInventory[i].kind] + "\n" + level[game.playerInventory[i].level];
        playerSelectText.GetComponent<TextMeshProUGUI>().color = textColors[game.playerInventory[i].kind];

        System.Random rand = new System.Random();
        int j = rand.Next(game.customer.inventory);

        customerSelect.GetComponent<Image>().sprite = Resources.Load<Sprite>(images[game.customerInventory[j].kind]);
        customerSelectText.GetComponent<TextMeshProUGUI>().text = theme[game.customerInventory[j].kind] + "\n" + level[game.customerInventory[j].level];
        customerSelectText.GetComponent<TextMeshProUGUI>().color = textColors[game.customerInventory[j].kind];

        game.selectInventory(i, j);

        GameObject.Find(string.Format("PlayerText{0}", i + 1)).GetComponent<TextMeshProUGUI>().text
            = theme[game.playerInventory[i].kind] + "\n" + level[game.playerInventory[i].level];
        GameObject.Find(string.Format("PlayerText{0}", i + 1)).GetComponent<TextMeshProUGUI>().color
            = textColors[game.playerInventory[i].kind];
        GameObject.Find(string.Format("PlayerButton{0}", i + 1)).GetComponent<Image>().sprite
            = Resources.Load<Sprite>(images[game.playerInventory[i].kind]);

        GameObject.Find(string.Format("CustomerText{0}", j + 1)).GetComponent<TextMeshProUGUI>().text
                = theme[game.customerInventory[j].kind];
        GameObject.Find(string.Format("CustomerText{0}", j + 1)).GetComponent<TextMeshProUGUI>().color
            = textColors[game.customerInventory[j].kind];
        GameObject.Find(string.Format("CustomerButton{0}", j + 1)).GetComponent<Image>().color
            = colors[game.customerInventory[j].kind];

        tiredness.GetComponentInChildren<Slider>().value = (float)game.currentTired / game.maxTired;
        persuasion.GetComponentInChildren<Slider>().value = (float)game.currentHealth / game.maxHealth;

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
        else if(GameState.SCRIPT_KEY == "")
        {
            if (GameState.PROGRESS != "FIGHT")
            {
                GameState.SCRIPT_KEY = "victory";
                chattingBar.SetActive(true);
                GameState.IS_PAUSED = true;

            }
            else
            {
                GameState.SCRIPT_KEY = "day5_girlfriend_fight_victory";
                chattingBar.SetActive(true);
                GameState.IS_PAUSED = true;
                GameState.PROGRESS = "VICTORY";
                cinemaUI.SetActive(true);


                return;
            }
        }

        sellingPopup.SetActive(false);
        GameState.IS_POPPED_UP = false;
        GameState.STAT_POINT++;
        GameState.TODAY_CALLED_CUSTOMER++;
    }

    void lose()
    {
        if (GameState.SCRIPT_KEY == "day1_office_sellingFailed")
        {
            chattingBar.SetActive(true);
            GameState.IS_PAUSED = true;
        }
        else if (GameState.SCRIPT_KEY == "")
        {
            GameState.SCRIPT_KEY = "looose";
            chattingBar.SetActive(true);
            GameState.IS_PAUSED = true;
        }

        sellingPopup.SetActive(false);
        GameState.IS_POPPED_UP = false;
        GameState.TODAY_CALLED_CUSTOMER++;
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
