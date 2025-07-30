using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GameObject bullet = PlayerBulletPoolManager.Instance.SpawnBullet(bulletID, spawnPosition, spawnRotation);

public class PlayerBulletPoolManager : MonoBehaviour
{
    public static PlayerBulletPoolManager Instance;

    [System.Serializable]
    public class BulletEntry
    {
        public string bulletID;
        public GameObject prefab;
        public int initialSize = 10;
    }

    public List<BulletEntry> bulletTypes = new List<BulletEntry>();
    private Dictionary<string, List<GameObject>> bulletPools = new Dictionary<string, List<GameObject>>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        InitializePools();
    }

    void InitializePools()
    {
        foreach (var entry in bulletTypes)
        {
            if (!bulletPools.ContainsKey(entry.bulletID))
                bulletPools[entry.bulletID] = new List<GameObject>();

            for (int i = 0; i < entry.initialSize; i++)
            {
                GameObject bullet = Instantiate(entry.prefab);
                bullet.SetActive(false);
                bullet.transform.SetParent(transform);
                bulletPools[entry.bulletID].Add(bullet);
            }
        }
    }

    public GameObject SpawnBullet(string bulletID, Vector3 position, Quaternion rotation)
    {
        if (!bulletPools.ContainsKey(bulletID))
        {
            Debug.LogWarning("Bullet pool not found: " + bulletID);
            return null;
        }

        foreach (GameObject bullet in bulletPools[bulletID])
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.transform.position = position;
                bullet.transform.rotation = rotation;
                bullet.SetActive(true);
                return bullet;
            }
        }

        GameObject prefab = GetPrefab(bulletID);
        GameObject newBullet = Instantiate(prefab, position, rotation);
        newBullet.transform.SetParent(transform);
        bulletPools[bulletID].Add(newBullet);
        return newBullet;
    }

    public void ReturnToPool(GameObject bullet)
    {
        bullet.SetActive(false);
    }

    private GameObject GetPrefab(string bulletID)
    {
        foreach (var entry in bulletTypes)
        {
            if (entry.bulletID == bulletID)
                return entry.prefab;
        }
        return null;
    }
}
