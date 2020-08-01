using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBarController : MonoBehaviour
{
    public static UIHealthBarController instance;
    public ShipController shipController;

    public int maxhealth;
    public Text healthText;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        RestartValues();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBarValue();
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
