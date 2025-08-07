using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EquippedSlots
{
    public string equippedWeaponID;
    public string equippedPetID;
    public string equippedDroneID;
    public List<string> equippedEquipments = new List<string>();
}
