using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Follower : MonoBehaviour {

	public Transform target;
	public Vector3 offset;
	public float followSpeed = 10f;

	public void Init(Transform newTarget, Vector3 newOffset)
	{
		target = newTarget;
		offset = newOffset;
	}

	void Update()
	{
		if (target == null) return;
		Vector3 desiredPos = target.position + offset;
		transform.position = Vector3.Lerp(transform.position, desiredPos, followSpeed * Time.deltaTime);
	}

	public void Deactivate()
	{
		gameObject.SetActive(false);
	}
}
