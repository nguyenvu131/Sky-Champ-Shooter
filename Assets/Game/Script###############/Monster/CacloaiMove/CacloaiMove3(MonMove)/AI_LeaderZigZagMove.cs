using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_LeaderZigZagMove : MonoBehaviour {

	//zigzagAmplitude: biên độ lượn (độ rộng)
	//zigzagFrequency: tần số (tốc độ lượn qua lại)

	public float moveSpeed = 2f;
	public float zigzagAmplitude = 2f;
	public float zigzagFrequency = 2f;

	private Vector3 startPosition;
	private float time;

	void Start()
	{
		startPosition = transform.position;
	}

	void Update()
	{
		time += Time.deltaTime;
		float x = Mathf.Sin(time * zigzagFrequency) * zigzagAmplitude;
		float y = -moveSpeed * time;
		transform.position = startPosition + new Vector3(x, y, 0);
	}
}
