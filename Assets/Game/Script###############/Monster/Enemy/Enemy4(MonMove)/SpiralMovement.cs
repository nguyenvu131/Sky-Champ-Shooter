using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralMovement : MonoBehaviour {

	public float speed = 1.5f;
	public float spiralSpeed = 5f;
	public float radius = 1f;
	private float angle;

	void Update() {
		angle += spiralSpeed * Time.deltaTime;
		float x = Mathf.Cos(angle) * radius;
		float y = Mathf.Sin(angle) * radius;
		transform.Translate(Vector3.down * speed * Time.deltaTime);
		transform.position += new Vector3(x, y, 0) * Time.deltaTime;
	}
}
