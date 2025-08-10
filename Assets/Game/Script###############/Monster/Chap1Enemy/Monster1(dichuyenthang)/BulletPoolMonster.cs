using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponTypeMonster {
	Normal,
	Laser,
	Rocket,
	// Add more if needed
}

public class BulletPoolMonster : MonoBehaviour {

	public static BulletPoolMonster Instance;

	[System.Serializable]
	public class BulletPoolData {
		public WeaponTypeMonster type;
		public GameObject prefab;
		public int initialSize = 10;
	}

	public List<BulletPoolData> bulletTypes;
	private Dictionary<WeaponTypeMonster, List<GameObject>> poolDict;

	void Awake() {
		Instance = this;
		poolDict = new Dictionary<WeaponTypeMonster, List<GameObject>>();

		foreach (var data in bulletTypes) {
			List<GameObject> pool = new List<GameObject>();
			for (int i = 0; i < data.initialSize; i++) {
				GameObject obj = Instantiate(data.prefab);
				obj.SetActive(false);
				pool.Add(obj);
			}
			poolDict[data.type] = pool;
		}
	}

	public GameObject GetBullet(WeaponTypeMonster type) {
		if (!poolDict.ContainsKey(type)) {
			Debug.LogWarning("WeaponType not found in pool: " + type);
			return null;
		}

		List<GameObject> pool = poolDict[type];
		//  Tìm viên đạn chưa active
		foreach (GameObject bullet in pool) {
			if (bullet != null && !bullet.activeInHierarchy) {
				return bullet;
			}
		}
		// ✅ Lọc các object null (đã Destroy) ra khỏi pool
		for (int i = pool.Count - 1; i >= 0; i--) {
			if (pool[i] == null) {
				pool.RemoveAt(i);
			}
		}

		foreach (GameObject bullet in pool) {
			if (!bullet.activeInHierarchy) {
				return bullet;
			}
		}

		//  Đoạn này gây lỗi nếu prefab null hoặc bị destroy
		GameObject prefab = GetPrefabByType(type);
		if (prefab == null) {
			Debug.LogError("Prefab null cho type: " + type);
			return null;
		}

		// Nếu không có bullet rảnh → tạo mới và thêm vào pool
		GameObject newBullet = Instantiate(GetPrefabByType(type));
		newBullet.SetActive(false);
		pool.Add(newBullet);
		return newBullet;
	}

	private GameObject GetPrefabByType(WeaponTypeMonster type) {
		foreach (var data in bulletTypes) {
			if (data.type == type)
				return data.prefab;
		}
		return null;
	}
}
