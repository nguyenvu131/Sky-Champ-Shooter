using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBezierMove : MonoBehaviour {

	public Transform point0, point1, point2;
	public float duration = 3f;
	private float t;

	void Update() {
		t += Time.deltaTime / duration;
		if (t > 1f) return;
		Vector3 p0 = point0.position;
		Vector3 p1 = point1.position;
		Vector3 p2 = point2.position;
		transform.position = Mathf.Pow(1 - t, 2) * p0 +
			2 * (1 - t) * t * p1 +
			Mathf.Pow(t, 2) * p2;
	}
}
