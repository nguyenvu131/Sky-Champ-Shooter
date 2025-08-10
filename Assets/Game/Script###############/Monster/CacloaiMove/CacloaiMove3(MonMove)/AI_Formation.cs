using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Formation : MonoBehaviour {

	public Transform leader;            // Monster đứng đầu nhóm
	public Vector2 offset;             // Vị trí tương đối trong đội hình
	public float followSpeed = 5f;

	void Update()
	{
		if (leader == null) return;

		Vector3 targetPos = leader.position + (Vector3)offset;
		transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
	}
}
