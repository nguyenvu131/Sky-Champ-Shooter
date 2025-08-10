using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_LeaderDiagonalMove : MonoBehaviour {

	//AI Bay chéo
	//(-1, -1) → trái xuống
	//(1, -1) → phải xuống
	//(-1, 1) → trái lên
	//(1, 1) → phải lên

	public Vector2 direction = new Vector2(-1, -1); // trái xuống
	public float moveSpeed = 2f;

	void Update()
	{
		transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
	}
}
