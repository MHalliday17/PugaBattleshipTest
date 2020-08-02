using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Singleton")]
    public static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [Header("References")]
    public Transform pivotToRestart;
    public GameObject ship;

    [Header("Behaviour")]
    [HideInInspector] public float gameTime = 1;
    [HideInInspector] public bool endGame;

    public GameObject homeScreen;
    public GameObject customShipScreen;
    public GameObject endGameMenu;
    public Text endGameMenuText;


    void Awake()
    {
        instance = this;

        endGame = true;
        SpawnManager.Instance.spawnAble = false;
        gameTime = 0;
        Time.timeScale = 0f;
    }


    void Update()
    {
        if (Input.GetButton("Cancel") && endGame)
            RestatGame();
    }

    public void GoToHomeScreen()
    {
        CurrencyManager.instance.SaveCurrency();        
        CurrencyManager.instance.UpdateUITexts();
        homeScreen.SetActive(true);
        customShipScreen.SetActive(false);
        endGameMenu.SetActive(false);
        endGame = true;
        SpawnManager.Instance.spawnAble = false;
        gameTime = 0;
        Time.timeScale = 0f;
    }

    public void GoToCustomizeShipScreen()
    {
        CurrencyManager.instance.SaveCurrency();
        CurrencyManager.instance.UpdateUITexts();
        homeScreen.SetActive(false);
        customShipScreen.SetActive(true);
        endGameMenu.SetActive(false);
        endGame = true;
        SpawnManager.Instance.spawnAble = false;
        gameTime = 0;
        Time.timeScale = 0f;
    }


    public void EndGame(bool playerIsDead)
    {
        if (playerIsDead)
        {
            endGameMenuText.text = "Defeat";
            endGameMenuText.color = Color.red;
        }
        else
        {
            endGameMenuText.text = "Victory";
            endGameMenuText.color = Color.yellow;
        }
        CurrencyManager.instance.SaveCurrency();
        endGameMenu.SetActive(true);
        endGame = true;
        SpawnManager.Instance.spawnAble = false;
        gameTime = 0;
        Time.timeScale = 0f;
    }


    public void RestatGame()
    {
        TimeCounter.instance.RestartTimer();
        endGame = false;
        ship.transform.position = new Vector3(pivotToRestart.position.x, ship.transform.position.y, pivotToRestart.position.z);
        ship.GetComponent<ShipController>().allStatus[ship.GetComponent<ShipController>().healthLevel - 1].health = 100;
        ship.GetComponent<ShipController>().EnebleMesh(true);
        SpawnManager.Instance.DestroyerAllEnemy();
        SpawnManager.Instance.spawnAble = true;

        CurrencyManager.instance.SaveCurrency();
        UIHealthBarController.instance.RestartValues();
        homeScreen.SetActive(false);
        customShipScreen.SetActive(false);
        endGameMenu.SetActive(false);
        CurrencyManager.instance.totalCurrencys = 0;
        CurrencyManager.instance.UpdateUITexts();
        gameTime = 1;
        Time.timeScale = 1f;
    }
}
