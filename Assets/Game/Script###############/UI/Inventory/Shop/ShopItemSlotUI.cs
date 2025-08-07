using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemSlotUI : MonoBehaviour
{
    public Text nameText;
    public Text priceText;
    public Button buyButton;

    private ShopItem item;
    private ShopUIManager uiManager;

    public void Setup(ShopItem newItem, ShopUIManager manager)
    {
        item = newItem;
        uiManager = manager;

        nameText.text = item.displayName;
        priceText.text = item.price + " Gold";

        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(OnBuyClick);
    }

    void OnBuyClick()
    {
        ShopManager.Instance.BuyItem(item);
        uiManager.RefreshGoldUI();
    }
}
