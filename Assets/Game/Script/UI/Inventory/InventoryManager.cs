using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

	public static InventoryManager Instance;

    public List<EquipmentData> equipmentList = new List<EquipmentData>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddEquipment(EquipmentData item)
    {
        equipmentList.Add(item);
    }

    public void RemoveEquipment(EquipmentData item)
    {
        equipmentList.Remove(item);
    }
}
