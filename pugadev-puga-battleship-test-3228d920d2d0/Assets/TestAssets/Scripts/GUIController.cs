using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    public static GUIController instance;
    private CurrencyManager currencyManager;
    public ShipController shipController;

    public Text currencyText;

    public Text healthText;
    public int maxhealth;

    private void Awake()
    {
        instance = this;
        currencyManager = CurrencyManager.instance;
    }

    void Start()
    {
        RestartValues();
    }

    void Update()
    {
        UpdateCurrencyText();
        UpdateBarValue();
        Debug.Log(shipController.allStatus[shipController.healthLevel - 1].health);
    }

    public void UpdateCurrencyText()
    {
        currencyText.text = currencyManager.totalCurrencys.ToString();
    }

    public void UpdateBarValue()
    {
        int healthValue = shipController.allStatus[shipController.healthLevel - 1].health;
        healthText.text = healthValue + "/" + maxhealth;
    }

    public void RestartValues()
    {
        maxhealth = shipController.allStatus[shipController.healthLevel - 1].health;
    }
}
