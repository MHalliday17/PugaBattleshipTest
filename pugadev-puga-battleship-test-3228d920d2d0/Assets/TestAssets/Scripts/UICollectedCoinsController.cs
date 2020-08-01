using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICollectedCoinsController : MonoBehaviour
{
    public Text coinsHUDText;

    public Text coinsHomeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinsHUDText.text = CurrencyManager.instance.totalCurrencys.ToString();
    }

    public void UpdateTextValues()
    {

    }
}
