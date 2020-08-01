using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyName", menuName = "New Enemy")]
public class EnemyStats : ScriptableObject
{    
    [Header("Settings")]
    public EnemysType enemyType;
    public List<EnemysStatus> status;
    public int level = 1;
    public int myCurrencyToDrop;
    public float MaxDistanceToDrop;      
}
