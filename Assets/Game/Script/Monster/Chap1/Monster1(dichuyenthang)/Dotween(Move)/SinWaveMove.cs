using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinWaveMove : MonoBehaviour {

	public float speed = 2f;         // Tốc độ di chuyển theo Y
    public float amplitude = 1f;     // Biên độ sóng (X lắc mạnh cỡ nào)
    public float frequency = 2f;     // Tần số sóng (lắc nhanh hay chậm)

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newX = startPos.x + Mathf.Sin(Time.time * frequency) * amplitude;
        float newY = transform.position.y - speed * Time.deltaTime;
        transform.position = new Vector3(newX, newY, transform.position.z);
    }
}
