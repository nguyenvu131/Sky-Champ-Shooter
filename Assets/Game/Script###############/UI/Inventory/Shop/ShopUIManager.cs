using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour
{
    public Transform contentPanel;
    public GameObject shopItemSlotPrefab;
    public Text goldText;

    void Start()
    {
        RefreshShopUI();
        RefreshGoldUI();
    }

    public void RefreshShopUI()
    {
        foreach (Transform child in contentPanel)
            Destroy(child.gameObject);

        List<ShopItem> items = ShopManager.Instance.shopItems;

        foreach (ShopItem item in items)
        {
            GameObject slot = Instantiate(shopItemSlotPrefab, contentPanel);
            ShopItemSlotUI ui = slot.GetComponent<ShopItemSlotUI>();
            ui.Setup(item, this);
        }
    }

    public void RefreshGoldUI()
    {
        goldText.text = "Gold: " + PlayerGoldManager.Instance.currentGold.ToString();
    }
}
