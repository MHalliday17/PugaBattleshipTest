using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSettingsManager : MonoBehaviour
{
    public static ShipSettingsManager instance;

    public SecondaryCannonType mySecondaryCannonType;
    public DroneType myDroneType;
    
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

        LoadShipCannonSettings();
        LoadShipDroneSettings();
    }

    public void SaveShipSettings()
    {
        SaveSystem.SaveShipSettings(this);
    }

    public SecondaryCannonType LoadShipCannonSettings()
    {
        ShipSettingsData shipData = SaveSystem.LoadShipSettings();

        mySecondaryCannonType = shipData.mySecondaryCannonType;        

        return shipData.mySecondaryCannonType;
    }

    public DroneType LoadShipDroneSettings()
    {
        ShipSettingsData shipData = SaveSystem.LoadShipSettings();

        myDroneType = shipData.myDroneType;        

        return shipData.myDroneType;
    }
}
