using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour {

	public static ShopManager Instance;

	public List<ShopItemData> shopItems = new List<ShopItemData>();
	public ShopUI ui;

	void Awake()
	{
		Instance = this;
	}



	public void BuyItem(ShopItemData shopItem)
	{
		if (PlayerCurrency.Instance.SpendGold(shopItem.price))
		{
//			InventoryManager.Instance.AddItem(shopItem.item, 1);
			ui.Refresh();
			Debug.Log("Mua thành công: " + shopItem.item.itemName);
		}
		else
		{
			Debug.Log("Không đủ vàng!");
		}
	}

	public void SellItem(ItemData item)
	{
		ShopItemData shopEntry = shopItems.Find(s => s.item == item);
		if (shopEntry != null)
		{
			InventoryManager.Instance.RemoveItem(item);
			PlayerCurrency.Instance.AddGold(shopEntry.sellPrice);
			ui.Refresh();
			Debug.Log("Bán thành công: " + item.itemName);
		}
	}
}
