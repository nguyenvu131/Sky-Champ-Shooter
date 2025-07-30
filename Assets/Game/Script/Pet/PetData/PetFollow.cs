using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetFollow : MonoBehaviour {

	public Transform player;
	public Vector3 offset = new Vector3(1.5f, 0, 0);
	public float followSpeed = 5f;

	void Update()
	{
		if (player == null) return;

		Vector3 targetPos = player.position + offset;
		transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
	}
}
