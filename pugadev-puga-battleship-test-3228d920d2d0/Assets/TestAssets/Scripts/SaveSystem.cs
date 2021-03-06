﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveCurrency(CurrencyManager currencyManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/currencySave.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        CurrencyData currencyData = new CurrencyData(currencyManager);

        formatter.Serialize(stream, currencyData);

        stream.Close();
    }

    public static CurrencyData LoadCurrency()
    {
        string path = Application.persistentDataPath + "/currencySave.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CurrencyData currencyData = formatter.Deserialize(stream) as CurrencyData;
            stream.Close();

            return currencyData;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveShipSettings(ShipSettingsManager shipManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/shipSettingsSave.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        ShipSettingsData shipData = new ShipSettingsData(shipManager);

        formatter.Serialize(stream, shipData);

        stream.Close();
    }

    public static ShipSettingsData LoadShipSettings()
    {
        string path = Application.persistentDataPath + "/shipSettingsSave.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ShipSettingsData shipData = formatter.Deserialize(stream) as ShipSettingsData;
            stream.Close();

            return shipData;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
