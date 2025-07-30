using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAIMove : MonoBehaviour {

	public float moveSpeed = 2f;
	public Vector2[] waypoints;
	private int currentIndex = 0;

	void Update()
	{
		if (waypoints.Length == 0) return;

		Vector3 target = waypoints[currentIndex];
		transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

		if (Vector3.Distance(transform.position, target) < 0.1f)
			currentIndex = (currentIndex + 1) % waypoints.Length;
	}
}
