using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    public void DropItem(string itemID, Vector3 position)
    {
        DropItemPoolManager.Instance.SpawnItem(itemID, position);
    }

    // Ví dụ: enemy chết thì drop random
    public void DropRandomLoot()
    {
        string[] lootTable = new string[] { "Coin", "Potion", "Gem" };
        int index = Random.Range(0, lootTable.Length);
        DropItem(lootTable[index], transform.position);
    }
}
