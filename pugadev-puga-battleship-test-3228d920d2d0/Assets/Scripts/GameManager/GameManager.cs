using UnityEngine;
using UnityEngine.SceneManagement;
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

        endGame = false;
        SpawnManager.Instance.spawnAble = true;
        gameTime = 1;
        Time.timeScale = 1f;        
    }

    private void Start()
    {
        RestatGame();
    }


    void Update()
    {
        if (Input.GetButton("Cancel") && endGame)
            RestatGame();
    }   

    public void EndGame(bool playerIsDead)
    {
        CurrencyManager.instance.SaveCurrency();
        endGame = true;
        SpawnManager.Instance.spawnAble = false;
        gameTime = 0;
        Time.timeScale = 0f;

        if (playerIsDead)
        {            
            Debug.Log(ship.GetComponent<ShipController>().allStatus[ship.GetComponent<ShipController>().healthLevel - 1].health);
            SceneManager.LoadScene(4);
        }
        else
        {            
            SceneManager.LoadScene(3);
        }
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

        GUIController.instance.RestartValues();        
        CurrencyManager.instance.totalCurrencys = 0;
        gameTime = 1;
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
