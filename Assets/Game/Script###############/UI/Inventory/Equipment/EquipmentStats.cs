using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EquipmentStats
{
    public int addHP = 0;
    public int addAttack = 0;
    public int addDefense = 0;
    public float addCritRate = 0f;
    public float addFireRate = 0f;

    public static EquipmentStats operator +(EquipmentStats a, EquipmentStats b)
    {
        EquipmentStats result = new EquipmentStats();
        result.addHP = a.addHP + b.addHP;
        result.addAttack = a.addAttack + b.addAttack;
        result.addDefense = a.addDefense + b.addDefense;
        result.addCritRate = a.addCritRate + b.addCritRate;
        result.addFireRate = a.addFireRate + b.addFireRate;
        return result;
    }
}
