using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour {

	public float speed = 3f;
	public Transform player;

	void OnEnable()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update()
	{
		if (player == null) return;

		Vector3 dir = (player.position - transform.position).normalized;
		transform.position += dir * speed * Time.deltaTime;
	}
}
