using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUISlot : MonoBehaviour {
    public EquipmentType slotType;
    public Image iconImage;
    public Text nameText;

    public void Refresh() {
        EquipmentItem item = EquipmentManager.Instance.GetEquipped(slotType);
        if (item != null) {
            iconImage.sprite = item.icon;
            iconImage.enabled = true;
            nameText.text = item.itemName;
        } else {
            iconImage.enabled = false;
            nameText.text = "(None)";
        }
    }

    // Gọi khi người dùng click vào slot
    public void OnClickSlot() {
        EquipmentItem current = EquipmentManager.Instance.GetEquipped(slotType);
        if (current != null) {
            EquipmentManager.Instance.Unequip(slotType);
            Refresh();
        }
    }
}
