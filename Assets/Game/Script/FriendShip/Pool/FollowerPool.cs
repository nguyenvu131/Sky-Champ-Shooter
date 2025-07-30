using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerPool : MonoBehaviour {

	public static FollowerPool Instance;
	public GameObject[] followerTypes; // Heal, Shield, Missile...
	private Queue<GameObject> pool = new Queue<GameObject>();

	void Awake()
	{
		Instance = this;
		foreach (var type in followerTypes)
		{
			for (int i = 0; i < 5; i++)
			{
				GameObject obj = Instantiate(type);
				obj.SetActive(false);
				pool.Enqueue(obj);
			}
		}
	}

	public GameObject GetFollower()
	{
		if (pool.Count > 0)
		{
			GameObject obj = pool.Dequeue();
			obj.SetActive(true);
			return obj;
		}

		// fallback nếu hết pool
		return Instantiate(followerTypes[Random.Range(0, followerTypes.Length)]);
	}

	public void ReturnFollower(GameObject obj)
	{
		obj.SetActive(false);
		pool.Enqueue(obj);
	}
}
