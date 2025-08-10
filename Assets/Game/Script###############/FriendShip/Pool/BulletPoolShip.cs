using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolShip : MonoBehaviour {

	public static BulletPoolShip Instance;
	public GameObject bulletPrefab;
	public int poolSize = 20;

	private Queue<GameObject> pool = new Queue<GameObject>();

	void Awake()
	{
		Instance = this;
		for (int i = 0; i < poolSize; i++)
		{
			GameObject obj = Instantiate(bulletPrefab);
			obj.SetActive(false);
			pool.Enqueue(obj);
		}
	}

	public GameObject GetBullet()
	{
		if (pool.Count > 0)
		{
			GameObject obj = pool.Dequeue();
			obj.SetActive(true);
			return obj;
		}

		GameObject newObj = Instantiate(bulletPrefab);
		return newObj;
	}

	public void ReturnBullet(GameObject obj)
	{
		obj.SetActive(false);
		pool.Enqueue(obj);
	}
}
