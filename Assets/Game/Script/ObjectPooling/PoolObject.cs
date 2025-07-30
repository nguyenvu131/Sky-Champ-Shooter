using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour {

	public float lifetime = 10f;
	private float timer;

	void OnEnable()
	{
		timer = 0f;
	}

	void Update()
	{
		timer += Time.deltaTime;
		if (timer >= lifetime)
		{
			gameObject.SetActive(false);
		}
	}

	public void ReturnToPool()
	{
		gameObject.SetActive(false);
	}
}
