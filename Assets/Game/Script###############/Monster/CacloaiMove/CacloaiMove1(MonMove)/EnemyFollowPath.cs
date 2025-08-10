using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPath : MonoBehaviour {

	public Transform[] waypoints;
	public float speed = 2f;
	private int currentIndex = 0;

	void Update()
	{
		if (waypoints.Length == 0) return;

		transform.position = Vector3.MoveTowards(transform.position, waypoints[currentIndex].position, speed * Time.deltaTime);

		if (Vector3.Distance(transform.position, waypoints[currentIndex].position) < 0.1f)
		{
			currentIndex++;
			if (currentIndex >= waypoints.Length)
				// this.gameObject.SetActive(false); // hoàn thành path
				 enabled = false;
		}
	}
}
