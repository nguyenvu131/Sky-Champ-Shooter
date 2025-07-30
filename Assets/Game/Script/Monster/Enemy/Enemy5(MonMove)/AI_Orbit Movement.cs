using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_OrbitMovement : MonoBehaviour {

	public Transform centerTarget;
	public float orbitSpeed = 50f;
	public float orbitRadius = 2f;
	private float angle;

	void Update()
	{
		if (centerTarget == null) return;

		angle += orbitSpeed * Time.deltaTime;
		float rad = angle * Mathf.Deg2Rad;

		Vector3 offset = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0) * orbitRadius;
		transform.position = centerTarget.position + offset;
	}
}
