using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagMove : MonoBehaviour {

	public float moveSpeed = 3f;         // Tốc độ di chuyển ngang
    public float frequency = 3f;         // Tần số sóng sine
    public float magnitude = 1.5f;       // Biên độ sóng sine

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float x = transform.position.x - moveSpeed * Time.deltaTime;
        float y = startPosition.y + Mathf.Sin(Time.time * frequency) * magnitude;

        transform.position = new Vector3(x, y, 0);
    }
}
