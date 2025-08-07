using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PoolManager.Instance.SpawnFromPool("Bullet", firePoint.position, Quaternion.identity);

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size = 10;
    }

    public List<Pool> pools;
    public bool autoExpand = true; // Cho phép tự mở rộng nếu pool hết object
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    void Awake()
    {
        // Singleton
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            if (pool.prefab == null)
            {
                Debug.LogError("Prefab cho tag '" + pool.tag + "' chưa được gán!");
                continue;
            }

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool với tag không tồn tại: " + tag);
            return null;
        }

        Queue<GameObject> poolQueue = poolDictionary[tag];

        if (poolQueue.Count == 0)
        {
            if (autoExpand)
            {
                Debug.LogWarning("Pool '" + tag + "' rỗng → tự động tạo thêm 1 object.");
                Pool poolConfig = pools.Find(p => p.tag == tag);
                if (poolConfig != null && poolConfig.prefab != null)
                {
                    GameObject newObj = Instantiate(poolConfig.prefab);
                    newObj.SetActive(true);
                    newObj.transform.position = position;
                    newObj.transform.rotation = rotation;
                    poolQueue.Enqueue(newObj); // thêm vào queue để sử dụng lần sau
                    return newObj;
                }
                else
                {
                    Debug.LogError("Không thể mở rộng pool '" + tag + "'. Prefab không hợp lệ.");
                    return null;
                }
            }
            else
            {
                Debug.LogError("Pool '" + tag + "' đã hết object! Tăng size hoặc bật autoExpand.");
                return null;
            }
        }

        GameObject objectToSpawn = poolQueue.Dequeue();
        if (objectToSpawn == null)
        {
            Debug.LogError("Object trong pool '" + tag + "' bị null.");
            return null;
        }

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        poolQueue.Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}
