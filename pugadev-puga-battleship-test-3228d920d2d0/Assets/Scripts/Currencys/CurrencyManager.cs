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

    [HideInInspector] public int totalCurrenciesSaved;

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
        totalCurrenciesSaved += valueToAdd;        
        UpdateUITexts();
    }

    public void UpdateUITexts()
    {
        coinsHUDText.text = totalCurrencys.ToString();
        coinsEndGameScreenText.text = totalCurrencys.ToString();
        coinsHomeScreenText.text = totalCurrenciesSaved.ToString();
    }

    public void ResetProgress()
    {        
        totalCurrenciesSaved = 0;
        SaveCurrency();
        UpdateUITexts();
    }

    public void SaveCurrency()
    {
        SaveSystem.SaveCurrency(this);
    }

    public void LoadCurrency()
    {
        CurrencyData currencyData = SaveSystem.LoadCurrency();

        totalCurrenciesSaved = currencyData.totalCurrency;
    }
}
