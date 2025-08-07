using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingUIManager : MonoBehaviour
{
    public Transform contentPanel;
    public GameObject recipeSlotPrefab;

    void Start()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        foreach (Transform child in contentPanel)
            Destroy(child.gameObject);

        List<CraftingRecipe> recipes = CraftingManager.Instance.recipes;

        foreach (CraftingRecipe recipe in recipes)
        {
            GameObject obj = Instantiate(recipeSlotPrefab, contentPanel);
            CraftingRecipeSlotUI slot = obj.GetComponent<CraftingRecipeSlotUI>();
            slot.Setup(recipe, this);
        }
    }
}
