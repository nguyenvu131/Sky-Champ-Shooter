using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class CraftingRecipeSlotUI : MonoBehaviour
{
    public Text resultNameText;
    public Text ingredientsText;
    public Button craftButton;

    private CraftingRecipe recipe;
    private CraftingUIManager uiManager;

    public void Setup(CraftingRecipe _recipe, CraftingUIManager manager)
    {
        recipe = _recipe;
        uiManager = manager;

        resultNameText.text = "Create: " + recipe.resultItemID;

        StringBuilder sb = new StringBuilder();
        foreach (CraftingIngredient ing in recipe.ingredients)
        {
            sb.AppendLine(ing.itemID + " x" + ing.quantity);
        }
        ingredientsText.text = sb.ToString();

        craftButton.onClick.RemoveAllListeners();
        craftButton.onClick.AddListener(OnCraftClick);
    }

    void OnCraftClick()
    {
        CraftingManager.Instance.CraftItem(recipe);
        uiManager.RefreshUI();
    }
}
