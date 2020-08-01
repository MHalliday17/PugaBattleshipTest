using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;
    public static CurrencyManager Instance { get { return instance; } }


    [Header("References")]
    public GameObject coinMesh;

    [Header("Settings")]
    public int maxCountForCurrencys;

    [Header("Behaviour")]
    [HideInInspector] public int totalCurrencys;

    public Text coinsHUDText;
    public Text coinsEndGameScreenText;
    public Text coinsHomeScreenText;


    void Awake()
    {
        instance = this;
        UpdateUITexts();
    }


    public void AddCurrency(int valueToAdd)
    {
        totalCurrencys += valueToAdd;

        int savedTotalCurrencies = PlayerPrefs.GetInt("TotalCoins");
        savedTotalCurrencies += valueToAdd;
        PlayerPrefs.SetInt("TotalCoins", savedTotalCurrencies);
        UpdateUITexts();
    }

    public void UpdateUITexts()
    {
        coinsHUDText.text = totalCurrencys.ToString();
        coinsEndGameScreenText.text = totalCurrencys.ToString();
        coinsHomeScreenText.text = PlayerPrefs.GetInt("TotalCoins").ToString();
    }

    public void ResetProgress()
    {
        PlayerPrefs.SetInt("TotalCoins", 0);
        UpdateUITexts();
    }
}
