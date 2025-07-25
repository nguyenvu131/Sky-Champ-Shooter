using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPoolManager : MonoBehaviour {

	public static SkillPoolManager Instance;

	[System.Serializable]
	public class SkillPool {
		public string skillID;
		public GameObject prefab;
		public int poolSize = 5;
		[HideInInspector] public List<GameObject> pooledObjects = new List<GameObject>();
	}

	public List<SkillPool> skillPools;

	void Awake() {
		if (Instance == null) Instance = this;

		foreach (var pool in skillPools) {
			for (int i = 0; i < pool.poolSize; i++) {
				GameObject obj = Instantiate(pool.prefab);
				obj.SetActive(false);
				pool.pooledObjects.Add(obj);
			}
		}
	}

	public GameObject GetSkillObject(string skillID) {
		foreach (var pool in skillPools) {
			if (pool.skillID == skillID) {
				foreach (var obj in pool.pooledObjects) {
					if (!obj.activeInHierarchy) return obj;
				}

				// Nếu hết => Instantiate thêm
				GameObject newObj = Instantiate(pool.prefab);
				newObj.SetActive(false);
				pool.pooledObjects.Add(newObj);
				return newObj;
			}
		}
		return null;
	}
}
