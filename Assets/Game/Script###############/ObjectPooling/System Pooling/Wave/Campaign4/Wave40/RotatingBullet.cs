using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBullet : MonoBehaviour {

	private float angleSpeed = 100f;
    private float moveSpeed = 2f;
    private Vector3 dir;

    public void Init(float angle)
    {
        dir = Quaternion.Euler(0, 0, angle) * Vector3.up;
    }

    void Update()
    {
        transform.position += dir * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, angleSpeed * Time.deltaTime);
    }
}
