using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour {

	public static BulletPoolManager Instance;

    [System.Serializable]
    public class BulletEntry
    {
        public string bulletID;
        public GameObject prefab;
        public int initialPoolSize = 10;
    }

    public List<BulletEntry> bulletEntries = new List<BulletEntry>();
    private Dictionary<string, List<GameObject>> bulletPools = new Dictionary<string, List<GameObject>>();

    void Awake()
    {
        Instance = this;
        foreach (var entry in bulletEntries)
        {
            List<GameObject> pool = new List<GameObject>();
            for (int i = 0; i < entry.initialPoolSize; i++)
            {
                GameObject obj = Instantiate(entry.prefab);
                obj.SetActive(false);
                pool.Add(obj);
            }
            bulletPools[entry.bulletID] = pool;
        }
    }

    public GameObject SpawnBullet(string bulletID, Vector3 position)
    {
        if (!bulletPools.ContainsKey(bulletID))
        {
            Debug.LogWarning("Bullet ID not found: " + bulletID);
            return null;
        }

        foreach (GameObject bullet in bulletPools[bulletID])
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.transform.position = position;
                bullet.SetActive(true);
                return bullet;
            }
        }

        return null;
    }
}
