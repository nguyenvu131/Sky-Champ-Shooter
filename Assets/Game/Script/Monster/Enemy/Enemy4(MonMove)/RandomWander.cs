using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWander : MonoBehaviour {

	public float speed = 1f;
	private Vector3 direction;
	private float changeInterval = 1.5f;
	private float timer;

	void Start() {
		ChangeDirection();
	}

	void Update() {
		transform.Translate(direction * speed * Time.deltaTime);
		timer -= Time.deltaTime;
		if (timer <= 0) {
			ChangeDirection();
		}
	}

	void ChangeDirection() {
		float angle = Random.Range(0, 360);
		direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0).normalized;
		timer = changeInterval;
	}
}
