using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManagerHome : MonoBehaviour {

	public List<ShopItem> shopItems;
	public PlayerCurrencyHome playerCurrencyHome;

	public bool TryBuyItem(ShopItem item, float discount = 0f) {
		int finalPrice = item.GetFinalPrice(discount);
		if (playerCurrencyHome.HasEnough(item.currencyType, finalPrice)) {
			playerCurrencyHome.Spend(item.currencyType, finalPrice);
			Debug.Log("Mua thành công: " + item.itemName);
			return true;
		}
		Debug.Log("Không đủ tiền");
		return false;
	}
}
