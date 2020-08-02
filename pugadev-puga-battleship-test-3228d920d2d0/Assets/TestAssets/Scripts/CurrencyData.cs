using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CurrencyData
{
    public int totalCurrency;

    public CurrencyData (CurrencyManager currencyManager)
    {
        totalCurrency = currencyManager.totalCurrenciesSaved;
    }
}
