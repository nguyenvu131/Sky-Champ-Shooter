using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform contentPanel;
    public GameObject itemSlotPrefab;

    void Start()
    {
        RefreshInventoryUI();
    }

    public void RefreshInventoryUI()
    {
        foreach (Transform child in contentPanel)
            Destroy(child.gameObject);

        List<InventoryItem> items = InventoryManager.Instance.inventory;

        foreach (InventoryItem item in items)
        {
            GameObject slot = Instantiate(itemSlotPrefab, contentPanel);
            slot.GetComponentInChildren<Text>().text = item.itemID + " x" + item.quantity;

            // Có thể thêm hình ảnh, nút Equip, Lock...
        }
    }
}
