using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMovement : MonoBehaviour {

	public float speed = 2f;
	public float frequency = 5f;
	public float magnitude = 1f;

	private Vector3 axis;
	private Vector3 pos;

	void Start() {
		pos = transform.position;
		axis = transform.right;
	}

	void Update() {
		pos += Vector3.down * speed * Time.deltaTime;
		transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
	}
}
