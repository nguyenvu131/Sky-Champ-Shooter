using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollowerPool : MonoBehaviour {

	public static AIFollowerPool Instance;
	public GameObject followerPrefab;
	public int initialSize = 10;

	private Queue<GameObject> pool = new Queue<GameObject>();

	void Awake()
	{
		if (Instance == null) Instance = this;

		for (int i = 0; i < initialSize; i++)
		{
			GameObject obj = Instantiate(followerPrefab);
			obj.SetActive(false);
			pool.Enqueue(obj);
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

		GameObject newObj = Instantiate(followerPrefab);
		return newObj;
	}

	public void ReturnFollower(GameObject obj)
	{
		obj.SetActive(false);
		pool.Enqueue(obj);
	}
}
