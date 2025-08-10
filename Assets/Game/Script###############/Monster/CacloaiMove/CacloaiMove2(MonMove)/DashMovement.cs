using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMovement : MonoBehaviour {

	public float normalSpeed = 2f;
	public float dashSpeed = 7f;
	public float dashInterval = 3f;
	private float timer;

	void Update() {
		timer += Time.deltaTime;
		float speed = (timer >= dashInterval) ? dashSpeed : normalSpeed;
		transform.Translate(Vector3.down * speed * Time.deltaTime);

		if (timer >= dashInterval + 0.3f) timer = 0f;
	}
}
