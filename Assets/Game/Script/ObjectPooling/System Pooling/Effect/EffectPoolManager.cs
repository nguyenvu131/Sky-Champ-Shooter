using System.Collections;
using System.Collections.Generic;
using UnityEngine;
	//huong dan su dung
	// Vector3 deathPosition = transform.position;
    // EffectPoolManager.Instance.SpawnEffect("Explosion", deathPosition, Quaternion.identity);
	
public class EffectPoolManager : MonoBehaviour
{
    public static EffectPoolManager Instance;

    [System.Serializable]
    public class EffectEntry
    {
        public string effectName;
        public GameObject effectPrefab;
        public int initialPoolSize = 5;
    }

    public List<EffectEntry> effectEntries = new List<EffectEntry>();
    private Dictionary<string, List<GameObject>> effectPools = new Dictionary<string, List<GameObject>>();

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        InitializeAllPools();
    }

    void InitializeAllPools()
    {
        foreach (EffectEntry entry in effectEntries)
        {
            if (!effectPools.ContainsKey(entry.effectName))
            {
                effectPools[entry.effectName] = new List<GameObject>();
            }

            for (int i = 0; i < entry.initialPoolSize; i++)
            {
                GameObject obj = Instantiate(entry.effectPrefab);
                obj.SetActive(false);
                obj.transform.SetParent(this.transform);
                effectPools[entry.effectName].Add(obj);
            }
        }
    }

    public GameObject SpawnEffect(string effectName, Vector3 position, Quaternion rotation)
    {
        if (!effectPools.ContainsKey(effectName))
        {
            Debug.LogWarning("Effect not found in pool: " + effectName);
            return null;
        }

        foreach (GameObject obj in effectPools[effectName])
        {
            if (!obj.activeInHierarchy)
            {
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.SetActive(true);
                return obj;
            }
        }

        // Không đủ thì tạo thêm
        GameObject prefab = GetEffectPrefab(effectName);
        if (prefab != null)
        {
            GameObject newEffect = Instantiate(prefab, position, rotation);
            newEffect.transform.SetParent(this.transform);
            effectPools[effectName].Add(newEffect);
            newEffect.SetActive(true);
            return newEffect;
        }

        return null;
    }

    public void ReturnToPool(GameObject effect)
    {
        effect.SetActive(false);
    }

    private GameObject GetEffectPrefab(string effectName)
    {
        foreach (EffectEntry entry in effectEntries)
        {
            if (entry.effectName == effectName)
                return entry.effectPrefab;
        }
        return null;
    }
}
