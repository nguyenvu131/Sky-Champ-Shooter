using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBulletPoolManager : MonoBehaviour
{
    public static MonsterBulletPoolManager Instance;

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

        foreach (var entry in bulletTypes)
        {
            List<GameObject> pool = new List<GameObject>();
            for (int i = 0; i < entry.initialSize; i++)
            {
                GameObject bullet = Instantiate(entry.prefab);
                bullet.SetActive(false);
                bullet.transform.SetParent(transform);
                pool.Add(bullet);
            }
            bulletPools[entry.bulletID] = pool;
        }
    }

    public GameObject GetBullet(string bulletID, Vector3 position, Quaternion rotation)
    {
        if (!bulletPools.ContainsKey(bulletID))
        {
            Debug.LogWarning("BulletID not found: " + bulletID);
            return null;
        }

        List<GameObject> pool = bulletPools[bulletID];

        foreach (var bullet in pool)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.transform.position = position;
                bullet.transform.rotation = rotation;
                bullet.SetActive(true);
                return bullet;
            }
        }

        // Nếu không còn bullet trống => tạo mới
        GameObject prefab = bulletTypes.Find(x => x.bulletID == bulletID).prefab;
        GameObject newBullet = Instantiate(prefab, position, rotation);
        newBullet.transform.SetParent(transform);
        pool.Add(newBullet);
        return newBullet;
    }

    public void ReturnBullet(string bulletID, GameObject bullet)
    {
        bullet.SetActive(false);
        bullet.transform.SetParent(transform);
    }
}