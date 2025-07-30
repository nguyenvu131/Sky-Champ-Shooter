using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetBulletPool : MonoBehaviour {

	public static PetBulletPool Instance;
	public GameObject bulletPrefab;
	public int poolSize = 10;
	private List<GameObject> pool = new List<GameObject>();

	void Awake() {
		Instance = this;
		for (int i = 0; i < poolSize; i++) {
			GameObject obj = Instantiate(bulletPrefab);
			obj.SetActive(false);
			pool.Add(obj);
		}
	}

	public GameObject GetBullet() {
		foreach (GameObject obj in pool) {
			if (!obj.activeInHierarchy)
				return obj;
		}
		return null;
	}
}
