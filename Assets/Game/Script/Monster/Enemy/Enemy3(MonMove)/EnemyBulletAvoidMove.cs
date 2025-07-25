using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// né đạn
public class EnemyBulletAvoidMove : MonoBehaviour {

	public float speed = 2f;
	public LayerMask bulletLayer;
	public float avoidDistance = 2f;

	void Update() {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, avoidDistance, bulletLayer);
		if (hit.collider != null) {
			Vector3 dodgeDir = Vector3.right * (Random.value > 0.5f ? 1 : -1);
			transform.position += dodgeDir * speed * Time.deltaTime;
		} else {
			transform.Translate(Vector3.down * speed * Time.deltaTime);
		}
	}
}
