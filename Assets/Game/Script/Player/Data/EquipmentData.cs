using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType {
    Weapon,
    Armor,
    Accessory,
	Chip,
	Core
}
[System.Serializable]
public class EquipmentData
{
    public string id;
    public string name;
    public EquipmentType type;
    public int level;
    public Sprite icon;

    public float bonusHP;
    public float bonusDamage;
    public float bonusFireRate;
    public float bonusCritChance;
    public float bonusMoveSpeed;
}
