using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour {

	public float moveSpeed = 2f;
	public float waveSpeed = 4f;
	public float waveHeight = 1f;
	private float originalX;

	void OnEnable()
	{
		originalX = transform.position.x;
	}

	void Update()
	{
		float x = originalX + Mathf.Sin(Time.time * waveSpeed) * waveHeight;
		transform.position = new Vector3(x, transform.position.y - moveSpeed * Time.deltaTime, 0);
	}
}
