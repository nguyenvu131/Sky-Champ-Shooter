using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySuicideAI : MonoBehaviour {

	public float speed = 4f;
	public float explodeRadius = 2f;
	private Transform player;

	void OnEnable()
	{
		player = GameObject.FindGameObjectWithTag("AIPlayer").transform;

	}

	void Update()
	{
		if (player == null) return;

		transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

		if (Vector3.Distance(transform.position, player.position) < explodeRadius)
		{
			Explode();
		}
	}

	void Explode()
	{
		// Gây sát thương vùng nếu có
		// ...
		this.gameObject.SetActive(false);
	}
}
