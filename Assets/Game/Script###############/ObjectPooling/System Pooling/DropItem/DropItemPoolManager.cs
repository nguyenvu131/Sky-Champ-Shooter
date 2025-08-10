using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemPoolManager : MonoBehaviour
{
    public static DropItemPoolManager Instance;

    [System.Serializable]
    public class ItemEntry
    {
        public string itemID;
        public GameObject prefab;
        public int initialPoolSize = 5;
    }

    public List<ItemEntry> itemEntries = new List<ItemEntry>();
    private Dictionary<string, List<GameObject>> itemPools = new Dictionary<string, List<GameObject>>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        InitPools();
    }

    void InitPools()
    {
        foreach (ItemEntry entry in itemEntries)
        {
            if (!itemPools.ContainsKey(entry.itemID))
                itemPools[entry.itemID] = new List<GameObject>();

            for (int i = 0; i < entry.initialPoolSize; i++)
            {
                GameObject item = Instantiate(entry.prefab);
                item.SetActive(false);
                item.transform.SetParent(this.transform);
                itemPools[entry.itemID].Add(item);
            }
        }
    }

    public GameObject SpawnItem(string itemID, Vector3 position)
    {
        if (!itemPools.ContainsKey(itemID))
        {
            Debug.LogWarning("Item not found in pool: " + itemID);
            return null;
        }

        foreach (var obj in itemPools[itemID])
        {
            if (!obj.activeInHierarchy)
            {
                obj.transform.position = position;
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject prefab = GetItemPrefab(itemID);
        if (prefab != null)
        {
            GameObject newItem = Instantiate(prefab, position, Quaternion.identity);
            newItem.transform.SetParent(this.transform);
            itemPools[itemID].Add(newItem);
            return newItem;
        }

        return null;
    }

    public void ReturnToPool(GameObject item)
    {
        item.SetActive(false);
    }

    private GameObject GetItemPrefab(string itemID)
    {
        foreach (ItemEntry entry in itemEntries)
        {
            if (entry.itemID == itemID)
                return entry.prefab;
        }
        return null;
    }
}
