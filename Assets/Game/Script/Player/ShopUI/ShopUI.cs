using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour {

	public GameObject itemSlotPrefab;
	public Transform itemParent;
	public Text goldText;

	List<GameObject> spawnedSlots = new List<GameObject>();

	void OnEnable()
	{
		Refresh();
	}

	public void Refresh()
	{
		goldText.text = "Vàng: " + PlayerCurrency.Instance.gold;

		foreach (GameObject obj in spawnedSlots)
			Destroy(obj);
		spawnedSlots.Clear();

		foreach (var shopItem in ShopManager.Instance.shopItems)
		{
			GameObject go = Instantiate(itemSlotPrefab, itemParent);
			go.transform.Find("Icon").GetComponent<Image>().sprite = shopItem.item.icon;
			go.transform.Find("Name").GetComponent<Text>().text = shopItem.item.itemName;
			go.transform.Find("Price").GetComponent<Text>().text = shopItem.price.ToString();

			Button btn = go.GetComponent<Button>();
			btn.onClick.AddListener(() => ShopManager.Instance.BuyItem(shopItem));

			spawnedSlots.Add(go);
		}
	}
}
