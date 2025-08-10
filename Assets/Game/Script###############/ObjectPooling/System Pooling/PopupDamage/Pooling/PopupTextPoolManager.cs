using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PopupTextPoolManager : MonoBehaviour
{
    public static PopupTextPoolManager Instance;

    [System.Serializable]
    public class PopupTextEntry
    {
        public string type; // "damage", "heal", "crit", etc.
        public GameObject prefab;
        public int initialPoolSize = 10;
    }

    public List<PopupTextEntry> popupTypes = new List<PopupTextEntry>();
    private Dictionary<string, List<GameObject>> popupPools = new Dictionary<string, List<GameObject>>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        InitializePools();
    }

    void InitializePools()
    {
        foreach (var entry in popupTypes)
        {
            if (!popupPools.ContainsKey(entry.type))
                popupPools[entry.type] = new List<GameObject>();

            for (int i = 0; i < entry.initialPoolSize; i++)
            {
                GameObject popup = Instantiate(entry.prefab);
                popup.SetActive(false);
                popup.transform.SetParent(transform);
                popupPools[entry.type].Add(popup);
            }
        }
    }

    public GameObject SpawnPopup(string type, Vector3 position, string text)
    {
        if (!popupPools.ContainsKey(type))
        {
            Debug.LogWarning("Popup pool not found: " + type);
            return null;
        }

        foreach (var popup in popupPools[type])
        {
            if (!popup.activeInHierarchy)
            {
                popup.transform.position = position;
                popup.SetActive(true);

                var popupScript = popup.GetComponent<PopupTextMonster>();
                if (popupScript != null)
                    popupScript.SetText(text);

                return popup;
            }
        }

        // Không đủ thì tạo thêm
        GameObject prefab = GetPopupPrefab(type);
        if (prefab != null)
        {
            GameObject newPopup = Instantiate(prefab, position, Quaternion.identity);
            newPopup.transform.SetParent(transform);
            popupPools[type].Add(newPopup);

            var popupScript = newPopup.GetComponent<PopupTextMonster>();
            if (popupScript != null)
                popupScript.SetText(text);

            newPopup.SetActive(true);
            return newPopup;
        }

        return null;
    }

    public void ReturnToPool(GameObject popup)
    {
        popup.SetActive(false);
    }

    GameObject GetPopupPrefab(string type)
    {
        foreach (var entry in popupTypes)
        {
            if (entry.type == type)
                return entry.prefab;
        }
        return null;
    }
}
