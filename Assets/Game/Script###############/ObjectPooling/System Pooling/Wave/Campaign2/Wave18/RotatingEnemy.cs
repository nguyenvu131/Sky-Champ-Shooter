using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingEnemy : MonoBehaviour {

	public float rotateSpeed = 1.5f;
    public float moveDownSpeed = 0.5f;
    public float radius = 2.5f;
    private float angle;
    private Vector3 centerPoint;

    public GameObject bulletPrefab;
    public float shootDelay = 1.5f;

    public void Setup(Vector3 center, float startAngle)
    {
        centerPoint = center;
        angle = startAngle;

        InvokeRepeating("Shoot", shootDelay, shootDelay);
    }

    void Update()
    {
        angle += rotateSpeed * Time.deltaTime;

        // Xoay quanh điểm tâm
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        centerPoint += Vector3.down * moveDownSpeed * Time.deltaTime; // Di chuyển tâm xuống dưới
        transform.position = centerPoint + new Vector3(x, y, 0);

        if (transform.position.y < -6f)
            Destroy(gameObject);
    }

    void Shoot()
    {
        if (bulletPrefab == null) return;

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Vector3 dir = Vector3.down;
        bullet.GetComponent<EnemyBullet18>().SetDirection(dir);
    }
}
