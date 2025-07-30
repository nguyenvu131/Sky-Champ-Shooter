using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EquipmentData
{
    public string id;
    public string name;
    public EquipmentType type;
    public int level;
    public Sprite icon;

    public int attack;
    public int defense;
    public int hp;
	
    public float bonusHP;
    public float bonusDamage;
    public float bonusFireRate;
    public float bonusCritChance;
    public float bonusMoveSpeed;
}
