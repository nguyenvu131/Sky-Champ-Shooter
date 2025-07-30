using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypointMove : MonoBehaviour {

	public Transform[] waypoints;
	public float speed = 2f;
	private int index = 0;

	void Update() {
		if (waypoints.Length == 0) return;
		Transform target = waypoints[index];
		transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		if (Vector3.Distance(transform.position, target.position) < 0.1f) {
			index = (index + 1) % waypoints.Length;
		}
	}
}
