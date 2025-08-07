using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralMove33 : MonoBehaviour {

	public float radius = 0.1f;
    public float angleSpeed = 200f; // độ mỗi giây
    public float moveSpeed = 1.5f;
    public bool isClockwise = true;

    private float currentAngle = 0f;
    private Vector3 center;

    void Start()
    {
        center = transform.position;
    }

    void Update()
    {
        float direction = isClockwise ? -1f : 1f;

        currentAngle += direction * angleSpeed * Time.deltaTime;
        radius += 0.05f * Time.deltaTime; // càng lúc càng xoáy rộng

        float radian = currentAngle * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0) * radius;
        transform.position = center + offset;
        center += Vector3.down * moveSpeed * Time.deltaTime;

        if (transform.position.y < -6f || Mathf.Abs(transform.position.x) > 10f)
            Destroy(gameObject);
    }
}
