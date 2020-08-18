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
     public int totalCurrencys;

     public int totalCurrenciesSaved;    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }


    public void AddCurrency(int valueToAdd)
    {
        totalCurrencys += valueToAdd;
        totalCurrenciesSaved += valueToAdd;
        SaveCurrency();
    }    

    public void ResetProgress()
    {        
        totalCurrenciesSaved = 0;
        SaveCurrency();
        if (MenuNavigation.instance != null)
        {
            MenuNavigation.instance.UpdateCurrencyText();
        }
    }

    public void SaveCurrency()
    {
        SaveSystem.SaveCurrency(this);
    }

    public int LoadCurrency()
    {
        CurrencyData currencyData = SaveSystem.LoadCurrency();

        totalCurrenciesSaved = currencyData.totalCurrency;

        return currencyData.totalCurrency;
    }
}
