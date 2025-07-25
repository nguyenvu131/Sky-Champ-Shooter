using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmMove : MonoBehaviour {

	public float speed = 2f;
    public float waveFrequency = 5f;
    public float waveAmplitude = 0.5f;

    private Vector3 startPos;
    private float timeOffset;

    void Start()
    {
        startPos = transform.position;
        timeOffset = Random.Range(0f, 2f * Mathf.PI); // lệch phase
    }

    void Update()
    {
        float x = transform.position.x - speed * Time.deltaTime;
        float y = startPos.y + Mathf.Sin(Time.time * waveFrequency + timeOffset) * waveAmplitude;

        transform.position = new Vector3(x, y, 0);
    }
}
