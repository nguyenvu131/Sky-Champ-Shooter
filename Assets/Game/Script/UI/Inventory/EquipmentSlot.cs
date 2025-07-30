using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour {

	public Image icon;
    private EquipmentData data;

    public void SetEquipment(EquipmentData equip)
    {
        data = equip;
        icon.sprite = equip.icon;
        icon.enabled = true;
    }

    public EquipmentData GetEquipment()
    {
        return data;
    }

    public void ClearSlot()
    {
        data = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
