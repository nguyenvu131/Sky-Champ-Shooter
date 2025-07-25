using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

	public static InventoryManager Instance;

	public List<ItemData> items = new List<ItemData>();
	public InventorySlot[] slots;

	private void Awake() {
		if (Instance == null) Instance = this;
		else Destroy(gameObject);
	}

	public bool AddItem(ItemData item) {
		foreach (InventorySlot slot in slots) {
			if (slot.IsEmpty()) {
				slot.SetItem(item);
				items.Add(item);
				return true;
			}
		}
		return false;
	}

	public void RemoveItem(ItemData item) {
		items.Remove(item);
		// Cập nhật lại UI slot...
	}
}
