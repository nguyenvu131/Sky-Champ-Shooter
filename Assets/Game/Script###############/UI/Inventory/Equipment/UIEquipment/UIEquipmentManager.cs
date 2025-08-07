using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEquipmentManager : MonoBehaviour
{
    public Transform contentPanel;
    public GameObject equipmentSlotPrefab;

    public Text detailText;

    void Start()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        foreach (Transform child in contentPanel)
            Destroy(child.gameObject);

        List<EquipmentItem> equipments = EquipmentManager.Instance.ownedEquipments;

        foreach (EquipmentItem item in equipments)
        {
            GameObject slotObj = Instantiate(equipmentSlotPrefab, contentPanel);
            EquipmentSlotUI slotUI = slotObj.GetComponent<EquipmentSlotUI>();
            slotUI.Setup(item, this);
        }

        ShowTotalStats();
    }

    public void Equip(string itemID)
    {
        EquipmentManager.Instance.Equip(itemID);
        RefreshUI();
    }

    public void Unequip(EquipmentSlotType type)
    {
        EquipmentManager.Instance.Unequip(type);
        RefreshUI();
    }

    void ShowTotalStats()
    {
        EquipmentStats total = EquipmentManager.Instance.GetTotalEquipmentStats();
        string statsText = string.Format("Total Stats:\nHP: +{0}\nATK: +{1}\nDEF: +{2}\nCRIT: +{3}%\nFIRE: +{4}%",
            total.addHP, total.addAttack, total.addDefense, total.addCritRate * 100f, total.addFireRate * 100f);

        detailText.text = statsText;
    }
}
