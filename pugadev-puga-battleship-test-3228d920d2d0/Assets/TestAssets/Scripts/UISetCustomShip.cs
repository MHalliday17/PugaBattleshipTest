using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISetCustomShip : MonoBehaviour
{
    //ShipController shipController;

    //public SecondaryCannonType mySecondaryCannonTypeUI;

    public Text cannonTypeText;
    public Text droneTypeText;

    // Start is called before the first frame update
    void Start()
    {
        //ShipSettingsManager.instance.SaveShipSettings();
        //ShipSettingsManager.instance.LoadShipCannonSettings();
        //ShipSettingsManager.instance.LoadShipDroneSettings();
        //shipController = GameObject.Find("AllShip").GetComponent<ShipController>();
        UpdateSelectedOptionsTexts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AlternateCannonType()
    {
        int enumMaxValue = System.Enum.GetValues(typeof(SecondaryCannonType)).Length - 1;
        //int currentValue = (int)shipController.mySecondaryCannonType;
        int currentValue = (int)ShipSettingsManager.instance.mySecondaryCannonType;

        if (currentValue == enumMaxValue)
        {
            //shipController.mySecondaryCannonType = 0;
            ShipSettingsManager.instance.mySecondaryCannonType = 0;
        }
        else
        {
            //shipController.mySecondaryCannonType += 1;
            ShipSettingsManager.instance.mySecondaryCannonType += 1;
        }

        //shipController.SetCurrentSecondaryCannon(shipController.mySecondaryCannonType);
        ShipSettingsManager.instance.SaveShipSettings();
        UpdateSelectedOptionsTexts();
    }

    public void AlternateDroneType()
    {
        int enumMaxValue = System.Enum.GetValues(typeof(DroneType)).Length - 1;
        //int currentValue = (int)shipController.myDroneType;
        int currentValue = (int)ShipSettingsManager.instance.myDroneType;

        if (currentValue == enumMaxValue)
        {
            //shipController.myDroneType = 0;
            ShipSettingsManager.instance.myDroneType = 0;
        }
        else
        {
            //shipController.myDroneType += 1;
            ShipSettingsManager.instance.myDroneType += 1;
        }

        //shipController.SetCurrentDrone(shipController.myDroneType);
        ShipSettingsManager.instance.SaveShipSettings();
        UpdateSelectedOptionsTexts();
    }

    public void UpdateSelectedOptionsTexts()
    {
        //cannonTypeText.text = shipController.mySecondaryCannonType.ToString();
        //droneTypeText.text = shipController.myDroneType.ToString();

        ShipSettingsManager.instance.LoadShipCannonSettings();
        ShipSettingsManager.instance.LoadShipDroneSettings();

        cannonTypeText.text = ShipSettingsManager.instance.mySecondaryCannonType.ToString();
        droneTypeText.text = ShipSettingsManager.instance.myDroneType.ToString();
    }
}
