using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Đạn bay kiểu sóng sin
public class WaveBullet : BaseEnemyBullet
{
    public float frequency = 10f;
    public float magnitude = 0.5f;
    private Vector3 axis;
    private Vector3 originalDir;
    private float elapsed = 0f;

    protected override void Init()
    {
        originalDir = transform.up;
        axis = transform.right;
    }

    protected override void Move()
    {
        elapsed += Time.deltaTime;
        Vector3 wave = axis * Mathf.Sin(elapsed * frequency) * magnitude;
        transform.position += (originalDir * speed + wave) * Time.deltaTime;
    }
}
