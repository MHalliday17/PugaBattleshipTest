using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISetCustomShip : MonoBehaviour
{
    ShipController shipController;

    public SecondaryCannonType mySecondaryCannonTypeUI;

    public Text cannonTypeText;
    public Text droneTypeText;

    // Start is called before the first frame update
    void Start()
    {
        shipController = GameObject.Find("AllShip").GetComponent<ShipController>();
        UpdateSelectedOptionsTexts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AlternateCannonType()
    {
        int enumMaxValue = System.Enum.GetValues(typeof(SecondaryCannonType)).Length - 1;
        int currenValue = (int)shipController.mySecondaryCannonType;
        if (currenValue == enumMaxValue)
        {
            shipController.mySecondaryCannonType = 0;
        }
        else
        {
            shipController.mySecondaryCannonType += 1;
        }

        shipController.SetCurrentSecondaryCannon(shipController.mySecondaryCannonType);
        UpdateSelectedOptionsTexts();
    }

    public void AlternateDroneType()
    {
        int enumMaxValue = System.Enum.GetValues(typeof(DroneType)).Length - 1;
        int currenValue = (int)shipController.myDroneType;
        if (currenValue == enumMaxValue)
        {
            shipController.myDroneType = 0;
        }
        else
        {
            shipController.myDroneType += 1;
        }

        shipController.SetCurrentDrone(shipController.myDroneType);
        UpdateSelectedOptionsTexts();
    }

    public void UpdateSelectedOptionsTexts()
    {
        cannonTypeText.text = shipController.mySecondaryCannonType.ToString();
        droneTypeText.text = shipController.myDroneType.ToString();
    }
}
