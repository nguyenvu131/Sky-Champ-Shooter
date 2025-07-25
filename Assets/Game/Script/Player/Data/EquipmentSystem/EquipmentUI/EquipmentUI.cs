using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentUI : MonoBehaviour {
    public EquipmentUISlot weaponSlot;
    public EquipmentUISlot armorSlot;
    public EquipmentUISlot accessorySlot;

    void OnEnable() {
        RefreshUI();
    }

    public void RefreshUI() {
        if (weaponSlot != null) weaponSlot.Refresh();
        if (armorSlot != null) armorSlot.Refresh();
        if (accessorySlot != null) accessorySlot.Refresh();
    }
}
