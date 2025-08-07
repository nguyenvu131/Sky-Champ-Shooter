using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_SpiralMovement : MonoBehaviour {

	public float spiralSpeed = 2f;
	public float radiusSpeed = 0.5f;

	private float angle = 0f;
	private float radius = 0f;

	void Update()
	{
		angle += spiralSpeed * Time.deltaTime;
		radius += radiusSpeed * Time.deltaTime;

		float x = Mathf.Cos(angle) * radius;
		float y = Mathf.Sin(angle) * radius;

		transform.position += new Vector3(x, y, 0) * Time.deltaTime;
	}
}
