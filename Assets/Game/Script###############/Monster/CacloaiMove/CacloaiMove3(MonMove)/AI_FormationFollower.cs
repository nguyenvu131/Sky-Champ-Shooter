using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_FormationFollower : MonoBehaviour {

	[Header("Thông tin đội hình")]
	public Transform leader; // Quái leader hoặc anchor point
	public Vector2 offset;   // Vị trí trong đội hình (so với leader)

	[Header("Di chuyển")]
	public float followSpeed = 5f;

	void Update()
	{
		if (leader == null) return;

		// Tính vị trí mục tiêu theo offset
		Vector3 targetPos = leader.position + (Vector3)offset;

		// Di chuyển mượt đến vị trí đó
		transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
	}
}
