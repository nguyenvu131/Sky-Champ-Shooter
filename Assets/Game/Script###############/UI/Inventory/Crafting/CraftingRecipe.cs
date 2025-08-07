using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CraftingIngredient
{
    public string itemID;
    public int quantity;
}

[System.Serializable]
public class CraftingRecipe
{
    public string recipeID;
    public string resultItemID;
    public ItemType resultItemType;
    public EquipmentSlotType equipmentSlotType;
    public EquipmentStats resultStats;
    public List<CraftingIngredient> ingredients = new List<CraftingIngredient>();
}
