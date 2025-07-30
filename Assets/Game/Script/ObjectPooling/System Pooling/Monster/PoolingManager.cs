using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour {

	public static PoolingManager Instance;

    private Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void CreatePool(string key, GameObject prefab, int amount)
    {
        if (!poolDictionary.ContainsKey(key))
        {
            poolDictionary[key] = new Queue<GameObject>();
            for (int i = 0; i < amount; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false);
                poolDictionary[key].Enqueue(obj);
            }
        }
    }

    public GameObject SpawnFromPool(string key, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(key))
        {
            Debug.LogWarning("Pool with key " + key + " doesn't exist.");
            return null;
        }

        GameObject obj = poolDictionary[key].Dequeue();
        obj.SetActive(true);
        obj.transform.position = position;
        obj.transform.rotation = rotation;

        poolDictionary[key].Enqueue(obj);
        return obj;
    }
}
