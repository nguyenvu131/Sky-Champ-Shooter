using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSkillPoolManager : MonoBehaviour
{
    public static MonsterSkillPoolManager Instance;

    [System.Serializable]
    public class SkillEntry
    {
        public string skillID;
        public GameObject prefab;
        public int initialSize = 5;
    }

    public List<SkillEntry> skillEntries = new List<SkillEntry>();
    private Dictionary<string, List<GameObject>> skillPools = new Dictionary<string, List<GameObject>>();

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        InitializePools();
    }

    void InitializePools()
    {
        foreach (var entry in skillEntries)
        {
            if (!skillPools.ContainsKey(entry.skillID))
                skillPools[entry.skillID] = new List<GameObject>();

            for (int i = 0; i < entry.initialSize; i++)
            {
                GameObject obj = Instantiate(entry.prefab);
                obj.SetActive(false);
                obj.transform.SetParent(this.transform);
                skillPools[entry.skillID].Add(obj);
            }
        }
    }

    public GameObject SpawnSkill(string skillID, Vector3 position, Quaternion rotation)
    {
        if (!skillPools.ContainsKey(skillID))
        {
            Debug.LogWarning("Skill Pool not found: " + skillID);
            return null;
        }

        foreach (GameObject obj in skillPools[skillID])
        {
            if (!obj.activeInHierarchy)
            {
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject prefab = GetPrefab(skillID);
        if (prefab != null)
        {
            GameObject newObj = Instantiate(prefab, position, rotation);
            newObj.transform.SetParent(this.transform);
            skillPools[skillID].Add(newObj);
            newObj.SetActive(true);
            return newObj;
        }

        return null;
    }

    public void ReturnToPool(GameObject skillObj)
    {
        skillObj.SetActive(false);
    }

    private GameObject GetPrefab(string skillID)
    {
        foreach (var entry in skillEntries)
        {
            if (entry.skillID == skillID)
                return entry.prefab;
        }
        return null;
    }
}
