using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitPlayer : MonoBehaviour {

	public float orbitSpeed = 1f;
	public float orbitRadius = 3f;
	private Transform player;
	private float angle;

	void Start() {
		player = GameObject.FindWithTag("Player").transform;
	}

	void Update() {
		if (player == null) return;

		angle += orbitSpeed * Time.deltaTime;
		float x = Mathf.Cos(angle) * orbitRadius;
		float y = Mathf.Sin(angle) * orbitRadius;
		transform.position = player.position + new Vector3(x, y, 0);
	}
}
