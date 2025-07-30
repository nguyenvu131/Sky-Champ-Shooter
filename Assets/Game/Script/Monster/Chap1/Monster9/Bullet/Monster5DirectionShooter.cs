using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster5DirectionShooter : MonoBehaviour {

	public GameObject bulletPrefab;
    public float bulletSpeed = 3f;
    public float fireRate = 2f;
    private float nextFire;

    // Các góc bắn theo độ (tỏa ra 5 hướng)
    private float[] angles = { -30f, -15f, 0f, 15f, 30f };

    void Update()
    {
        if (Time.time >= nextFire)
        {
            Shoot5Directions();
            nextFire = Time.time + 1f / fireRate;
        }
    }

    void Shoot5Directions()
    {
        foreach (float angle in angles)
        {
            // Tính toán hướng bắn dựa trên góc
            float rad = angle * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Sin(rad), -Mathf.Cos(rad)).normalized;

            // Tạo viên đạn và thiết lập vận tốc
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * bulletSpeed;
            }
        }
    }
}
