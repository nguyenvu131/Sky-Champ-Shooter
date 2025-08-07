using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_LeaderLinearMove : MonoBehaviour {

	//AI bay ngang sang trái
	public Vector2 direction = Vector2.left;
	public float moveSpeed = 2f;

	void Update()
	{
		transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
	}
}
