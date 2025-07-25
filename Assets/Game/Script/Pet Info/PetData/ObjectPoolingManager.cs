using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolObject1 {
    public string poolName;
    public GameObject prefab;
    public int amount;
}
// VD:
// GameObject bullet = ObjectPoolingManager.Instance.GetObject("PlayerBullet");
// if (bullet != null) {
    // bullet.transform.position = firePoint.position;
    // bullet.transform.rotation = Quaternion.identity;
    // bullet.SetActive(true);
    // bullet.GetComponent<Bullet>().SetDirection(Vector3.up);
// }

public class ObjectPoolingManager : MonoBehaviour {

	public static ObjectPoolingManager Instance;

    public List<PoolObject1> objectPools = new List<PoolObject1>();

    private Dictionary<string, List<GameObject>> poolDictionary = new Dictionary<string, List<GameObject>>();

    void Awake() {
        if (Instance == null) Instance = this;

        // Tạo tất cả pool
        for (int i = 0; i < objectPools.Count; i++) {
            PoolObject1 pool = objectPools[i];
            List<GameObject> objectList = new List<GameObject>();

            for (int j = 0; j < pool.amount; j++) {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectList.Add(obj);
            }

            poolDictionary.Add(pool.poolName, objectList);
        }
    }

    public GameObject GetObject(string poolName) {
        if (!poolDictionary.ContainsKey(poolName)) return null;

        List<GameObject> list = poolDictionary[poolName];

        for (int i = 0; i < list.Count; i++) {
            if (!list[i].activeInHierarchy) {
                return list[i];
            }
        }

        // Không đủ -> tạo thêm
        GameObject prefab = GetPrefabByName(poolName);
        if (prefab != null) {
            GameObject newObj = Instantiate(prefab);
            newObj.SetActive(false);
            list.Add(newObj);
            return newObj;
        }

        return null;
    }

    private GameObject GetPrefabByName(string name) {
        for (int i = 0; i < objectPools.Count; i++) {
            if (objectPools[i].poolName == name) {
                return objectPools[i].prefab;
            }
        }
        return null;
    }

    // Tiện ích lấy bullet theo prefab
    public GameObject GetBullet(GameObject prefab) {
        string name = prefab.name;
        return GetObject(name);
    }
}
