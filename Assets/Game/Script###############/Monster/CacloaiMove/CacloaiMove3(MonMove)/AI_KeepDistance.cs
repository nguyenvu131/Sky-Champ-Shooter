using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_KeepDistance : MonoBehaviour {

	public Transform player;
	public float idealDistance = 5f;
	public float moveSpeed = 3f;

	void Update()
	{
		if (player == null) return;

		float currentDist = Vector3.Distance(transform.position, player.position);
		Vector3 direction = (transform.position - player.position).normalized;

		if (currentDist < idealDistance - 0.5f)
		{
			// Lùi ra xa
			transform.position += direction * moveSpeed * Time.deltaTime;
		}
		else if (currentDist > idealDistance + 0.5f)
		{
			// Tiến lại gần
			transform.position -= direction * moveSpeed * Time.deltaTime;
		}
	}
}
