using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendFollow : MonoBehaviour {

	public Transform player;
	public float followSpeed = 5f;
	public float followDistance = 2f;

	void Update()
	{
		if (!player) return;

		Vector3 targetPos = player.position - player.up * followDistance;
		transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
		transform.up = Vector3.Lerp(transform.up, player.up, 0.1f);
	}
}
