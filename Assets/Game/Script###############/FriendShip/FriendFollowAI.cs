using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendFollowAI : MonoBehaviour {

	public Transform player;
	public float followDistance = 2f;
	public float moveSpeed = 5f;

	void Update()
	{
		Vector3 targetPos = player.position - player.up * followDistance;
		transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
		transform.up = Vector3.Lerp(transform.up, player.up, 0.2f); // định hướng giống player
	}
}
