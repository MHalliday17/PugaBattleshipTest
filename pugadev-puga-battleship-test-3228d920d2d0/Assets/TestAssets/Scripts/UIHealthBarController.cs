using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBarController : MonoBehaviour
{
    public static UIHealthBarController instance;
    public ShipController shipController;
    public Slider slider;

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
        slider.value = Mathf.Lerp(slider.value, healthValue, Time.deltaTime * 5f);
        healthText.text = healthValue + "/" + maxhealth;
    }

    public void RestartValues()
    {
        slider.maxValue = shipController.allStatus[shipController.healthLevel - 1].health;
        maxhealth = shipController.allStatus[shipController.healthLevel - 1].health;
    }
}
