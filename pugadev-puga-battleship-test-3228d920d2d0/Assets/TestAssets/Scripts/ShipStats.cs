using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewShipName", menuName = "New Ship")]
public class ShipStats : ScriptableObject
{
    [Header("Settings")]
    public ShipType myType;
    public List<StatusLevel> allStatus;    

    [Header("Behaviour")]
    public int damage;
    public int currentLife;
}
