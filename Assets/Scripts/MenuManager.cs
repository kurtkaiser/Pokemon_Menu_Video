using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject mainInfoPanel;
    public GameObject mainInfoText;

    public GameObject mainMenu;
    public Text[] mainMenuOptions;

    public GameObject movesInfoPanel;
    public Text[] movesTextInfo;

    public GameObject movesMenu;
    public Text[] movesOptions;

    [Header("Player Health")]
    public Text pokeName;
    public Text pokeLevel;
    public Text pokeHp;
    public GameObject healthBar;

    public GameObject poke1;
    public GameObject enemyPoke;

    public int cursorLocation = 0;

    private Text[] currentOptions;
    private GameObject infoPanel;
    private GameObject menuPanel;

    void Start()
    {
        currentOptions = mainMenuOptions;
        infoPanel = mainInfoPanel;
        menuPanel = mainMenu;
        NavigateMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(cursorLocation < 3)
            {
                cursorLocation = cursorLocation + 1;
                NavigateMenu();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(cursorLocation > 0)
            {
                cursorLocation--;
                NavigateMenu();
            }
        }
        if(cursorLocation < 0 || cursorLocation > 3)
        {
            cursorLocation = 0;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnSelection();
        }
    }

    void NavigateMenu()
    {
        ClearSelection();
        currentOptions[cursorLocation].text = "> " + currentOptions[cursorLocation].text;
    }

    void ClearSelection()
    {
        string firstTwo;
        string tempStr;
        for(int i = 0; i < currentOptions.Length; i++)
        {
            firstTwo = currentOptions[i].text.Substring(0, 2);
            if(firstTwo == "> ")
            {
                tempStr = currentOptions[i].text;
                currentOptions[i].text = tempStr.Substring(2, tempStr.Length - 2);
            }
        }
    }

    void OnSelection()
    {
        ClearSelection();
        if(menuPanel == mainMenu)
        {
            switch (cursorLocation)
            {
                case 0:
                    mainMenu.gameObject.SetActive(false);
                    mainInfoPanel.gameObject.SetActive(false);
                    movesMenu.gameObject.SetActive(true);
                    movesInfoPanel.gameObject.SetActive(true);
                    poke1.gameObject.SetActive(true);
                    enemyPoke.gameObject.SetActive(true);
                    currentOptions = movesOptions;
                    menuPanel = movesMenu;
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }
        else if (menuPanel == movesMenu)
        {
            switch (cursorLocation)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }
        cursorLocation = 0;
        NavigateMenu();
    }
}
