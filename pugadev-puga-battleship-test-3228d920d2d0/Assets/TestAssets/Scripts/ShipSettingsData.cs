using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShipSettingsData
{
    //public int cannonType;
    //public int droneType;

    public SecondaryCannonType mySecondaryCannonType;
    public DroneType myDroneType;

    public ShipSettingsData(ShipSettingsManager shipSettingsManager)
    {
        //cannonType = shipSettingsManager.cannonType;
        //droneType = shipSettingsManager.droneType;

        mySecondaryCannonType = shipSettingsManager.mySecondaryCannonType;
        myDroneType = shipSettingsManager.myDroneType;
    }
}
