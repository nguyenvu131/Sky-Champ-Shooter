using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentPanel : MonoBehaviour {

	public Transform slotRoot;
    public GameObject slotPrefab;

    public void RefreshPanel(List<EquipmentData> equipmentList)
    {
        foreach (Transform child in slotRoot)
            Destroy(child.gameObject);

        foreach (var equip in equipmentList)
        {
            GameObject go = Instantiate(slotPrefab, slotRoot);
            EquipmentSlot slot = go.GetComponent<EquipmentSlot>();
            slot.SetEquipment(equip);
        }
    }
}
