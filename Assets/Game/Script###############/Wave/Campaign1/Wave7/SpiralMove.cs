using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralMove : MonoBehaviour {

	public float spiralSpeed = 2f;       // Tốc độ tiến vào tâm
    public float rotationSpeed = 360f;   // Độ xoay quanh tâm (độ/giây)
    public float radius = 2f;            // Bán kính xoay ban đầu

    private float angle = 0f;
    private Vector3 center;
    private float lifetime = 0f;

    void Start()
    {
        center = transform.position;
    }

    void Update()
    {
        lifetime += Time.deltaTime;

        // Giảm bán kính theo thời gian (tiến vào tâm)
        float currentRadius = Mathf.Max(0, radius - spiralSpeed * lifetime);
        angle += rotationSpeed * Time.deltaTime;

        float rad = angle * Mathf.Deg2Rad;
        float x = center.x + currentRadius * Mathf.Cos(rad);
        float y = center.y + currentRadius * Mathf.Sin(rad);

        transform.position = new Vector3(x, y, 0);
    }
}
