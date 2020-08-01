using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICollectedCoinsController : MonoBehaviour
{
    public Text coinsTotalText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinsTotalText.text = CurrencyManager.instance.totalCurrencys.ToString();
    }
}
