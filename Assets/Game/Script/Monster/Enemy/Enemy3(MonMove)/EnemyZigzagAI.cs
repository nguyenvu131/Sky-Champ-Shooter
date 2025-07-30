using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZigzagAI : MonoBehaviour {

	public float speed = 0.5f;
	public float amplitude = 0.5f;
	public float frequency = 0.5f;

	public float startX;

	void OnEnable()
	{
		startX = transform.position.x;
	}

	void Update()
	{
		float offsetX = Mathf.Sin(Time.time * frequency) * amplitude;
		transform.position += new Vector3(offsetX, -speed * Time.deltaTime, 0);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("PlayerBullet"))
		{
			this.gameObject.SetActive(false);
		}
	}
}
