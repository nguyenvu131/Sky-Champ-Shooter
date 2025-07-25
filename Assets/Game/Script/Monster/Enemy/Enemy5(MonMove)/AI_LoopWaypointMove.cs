using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_LoopWaypointMove : MonoBehaviour {

	public Transform[] waypoints;
	public float moveSpeed = 3f;
	private int currentIndex = 0;

	void Update()
	{
		if (waypoints.Length == 0) return;

		Transform target = waypoints[currentIndex];
		transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

		if (Vector3.Distance(transform.position, target.position) < 0.1f)
		{
			currentIndex = (currentIndex + 1) % waypoints.Length;
		}
	}
}
