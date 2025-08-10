using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_BezierMove : MonoBehaviour {

	public Transform point0;
	public Transform point1;
	public Transform point2;
	public float moveTime = 5f;

	private float t;

	void Update()
	{
		if (t < 1f)
		{
			t += Time.deltaTime / moveTime;
			Vector3 pos = CalculateBezier(t, point0.position, point1.position, point2.position);
			transform.position = pos;
		}
	}

	Vector3 CalculateBezier(float t, Vector3 p0, Vector3 p1, Vector3 p2)
	{
		return Mathf.Pow(1 - t, 2) * p0 +
			2 * (1 - t) * t * p1 +
			Mathf.Pow(t, 2) * p2;
	}
}
