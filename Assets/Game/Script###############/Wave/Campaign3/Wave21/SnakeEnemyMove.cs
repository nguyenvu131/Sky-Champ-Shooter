using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeEnemyMove : MonoBehaviour {

	public float speed = 2f;
    public float amplitude = 1f;  // Biên độ sin
    public float frequency = 2f;  // Tần số
    public float offset = 0f;     // Để tạo hiệu ứng "đuôi" phía sau

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float time = Time.time + offset;
        float sinX = Mathf.Sin(time * frequency) * amplitude;
        transform.position += Vector3.down * speed * Time.deltaTime;
        transform.position = new Vector3(startPosition.x + sinX, transform.position.y, 0);
    }
}
