using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster3Shooter : MonoBehaviour {

	public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    private float fireCooldown = 0f;

    void Update()
    {
        fireCooldown -= Time.deltaTime;
        if (fireCooldown <= 0f)
        {
            Fire3BulletsDownward();
            fireCooldown = 1f / fireRate;
        }
    }

    void Fire3BulletsDownward()
    {
        float spreadAngle = 15f;

        // Góc lệch: trái (-15), giữa (0), phải (+15)
        FireBullet(firePoint.position, -spreadAngle);
        FireBullet(firePoint.position, 0f);
        FireBullet(firePoint.position, +spreadAngle);
    }

    void FireBullet(Vector3 position, float angleOffset)
    {
        GameObject bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
        float angle = -90f + angleOffset; // Hướng xuống là -90 độ
        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        bullet.GetComponent<Bullet3>().SetDirection(direction);
    }
}
