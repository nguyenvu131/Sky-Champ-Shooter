using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public static CraftingManager Instance;

    public List<CraftingRecipe> recipes = new List<CraftingRecipe>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        CreateTestRecipes();
    }

    void CreateTestRecipes()
    {
        CraftingRecipe swordRecipe = new CraftingRecipe();
        swordRecipe.recipeID = "recipe_sword";
        swordRecipe.resultItemID = "crafted_sword";
        swordRecipe.resultItemType = ItemType.Equipment;
        swordRecipe.equipmentSlotType = EquipmentSlotType.Accessory;
        swordRecipe.resultStats = new EquipmentStats { addAttack = 15 };

        swordRecipe.ingredients.Add(new CraftingIngredient { itemID = "iron_shard", quantity = 5 });
        swordRecipe.ingredients.Add(new CraftingIngredient { itemID = "fire_gem", quantity = 2 });

        recipes.Add(swordRecipe);
    }

    public bool CanCraft(CraftingRecipe recipe)
    {
        foreach (CraftingIngredient ingredient in recipe.ingredients)
        {
            InventoryItem item = InventoryManager.Instance.inventory.Find(i => i.itemID == ingredient.itemID);
            if (item == null || item.quantity < ingredient.quantity)
                return false;
        }
        return true;
    }

    public void CraftItem(CraftingRecipe recipe)
    {
        if (!CanCraft(recipe))
        {
            Debug.Log("Không đủ nguyên liệu!");
            return;
        }

        foreach (CraftingIngredient ingredient in recipe.ingredients)
        {
            InventoryManager.Instance.RemoveItem(ingredient.itemID, ingredient.quantity);
        }

        if (recipe.resultItemType == ItemType.Equipment)
        {
            EquipmentManager.Instance.AddEquipment(recipe.resultItemID, recipe.equipmentSlotType, recipe.resultStats);
        }
        else
        {
            InventoryManager.Instance.AddItem(recipe.resultItemID, recipe.resultItemType, 1);
        }

        Debug.Log("Chế tạo thành công: " + recipe.resultItemID);
    }
}
