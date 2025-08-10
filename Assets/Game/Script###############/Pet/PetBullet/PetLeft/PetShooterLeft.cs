using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetShooterLeft : MonoBehaviour {

	[Header("Bullet Settings")]
    public string bulletID = "PetBullet"; // ID tương ứng trong PlayerBulletPoolManager
    public Transform firePoint;
    public float fireRate = 1f;
    public float bulletSpeed = 10f;
    public float damage = 10f;

    private float fireCooldown;

    void Update()
    {
        HandleShooting();
    }

    void HandleShooting()
    {
        fireCooldown -= Time.deltaTime;

        if (fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = 1f / fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = PlayerBulletPoolManager.Instance.SpawnBullet(bulletID, firePoint.position, Quaternion.identity);

        if (bullet != null)
        {
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.velocity = Vector2.up * bulletSpeed;

            PetBulletLeft petBullet = bullet.GetComponent<PetBulletLeft>();
            if (petBullet != null)
                petBullet.damage = damage;
        }
    }
}
