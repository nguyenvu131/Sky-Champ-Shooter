using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class EquipmentSlotUI : MonoBehaviour
{
    public Text nameText;
    public Button actionButton;

    private EquipmentItem item;
    private UIEquipmentManager uiManager;

    public void Setup(EquipmentItem newItem, UIEquipmentManager manager)
    {
        item = newItem;
        uiManager = manager;
        nameText.text = item.equipmentID + (item.isEquipped ? " (Equipped)" : "");

        actionButton.GetComponentInChildren<Text>().text = item.isEquipped ? "Unequip" : "Equip";
        actionButton.onClick.RemoveAllListeners();
        actionButton.onClick.AddListener(OnActionButton);
    }

    void OnActionButton()
    {
        if (item.isEquipped)
            uiManager.Unequip(item.slotType);
        else
            uiManager.Equip(item.equipmentID);
    }
}
