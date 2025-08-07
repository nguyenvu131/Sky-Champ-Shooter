using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EquipmentItem
{
    public string equipmentID;
    public EquipmentSlotType slotType;
    public EquipmentStats stats;
    public int level = 1;
    public int star = 1;
    public bool isEquipped = false;

    public EquipmentItem(string id, EquipmentSlotType type)
    {
        equipmentID = id;
        slotType = type;
        stats = new EquipmentStats();
    }
}
