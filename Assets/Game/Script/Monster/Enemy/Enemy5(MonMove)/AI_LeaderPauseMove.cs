using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_LeaderPauseMove : MonoBehaviour {

	public float moveSpeed = 2f;
	public float moveDuration = 2f;
	public float pauseDuration = 1f;

	private float timer;
	private bool isMoving = true;

	void Update()
	{
		timer += Time.deltaTime;

		if (isMoving)
		{
			transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
			if (timer >= moveDuration)
			{
				timer = 0;
				isMoving = false;
			}
		}
		else
		{
			if (timer >= pauseDuration)
			{
				timer = 0;
				isMoving = true;
			}
		}
	}
}
