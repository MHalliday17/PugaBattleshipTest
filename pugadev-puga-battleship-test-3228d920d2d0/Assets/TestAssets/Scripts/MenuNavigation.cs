using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuNavigation : MonoBehaviour
{
    public static MenuNavigation instance;

    public Text savedCurrencyText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, self-destructing...");
            Destroy(this);
        }
    }

    void Start()
    {
        UpdateCurrencyText();        
    }

    void Update()
    {
        
    }

    public void UpdateCurrencyText()
    {
        if (savedCurrencyText != null)
        {
            savedCurrencyText.text = CurrencyManager.instance.LoadCurrency().ToString();
        }
    }

    public void GoToHomeScreen()
    {        
        SceneManager.LoadScene(0);
    }

    public void GoToCustomizeShipScreen()
    {        
        SceneManager.LoadScene(1);
    }

    public void PlayGame()
    {        
        SceneManager.LoadScene(2);
    }

    public void ResetProgress()
    {
        GameObject.FindObjectOfType<CurrencyManager>().ResetProgress();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
