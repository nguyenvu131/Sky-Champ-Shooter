using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpreadShooter : MonoBehaviour {

	public GameObject bulletPrefab;
    public int bulletCount = 5; // số viên đạn mỗi lần bắn
    public float spreadAngle = 45f; // tổng góc spread
    public float bulletSpeed = 3f;
    public float fireRate = 2f;

    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            FireSpreadShot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void FireSpreadShot()
    {
        float startAngle = -spreadAngle / 2f;
        float angleStep = spreadAngle / (bulletCount - 1);

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = startAngle + i * angleStep;
            Quaternion rotation = Quaternion.Euler(0, 0, angle + transform.eulerAngles.z);
            Vector3 dir = rotation * Vector3.down;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;
        }
    }
}
