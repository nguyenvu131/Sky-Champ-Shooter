using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShooter2 : MonoBehaviour
{
	public string bulletTag = "EnemyBullet";     // Tag của bullet trong PoolManager
    public Transform firePoint;              // Vị trí bắn
    public GameObject bulletPrefab;          // Prefab đạn (nên dùng từ ObjectPool)
    public float fireRate = 1f;              // Số lần bắn mỗi giây
    public float bulletSpeed = 5f;           // Tốc độ đạn
    public float detectRange = 10f;          // Khoảng cách thấy player

    private float fireCooldown = 0f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= detectRange)
        {
            RotateToTarget();
            TryFire();
        }
    }

    void RotateToTarget()
    {
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0, 0, angle);
    }

    void TryFire()
    {
        fireCooldown -= Time.deltaTime;
        if (fireCooldown <= 0f)
        {
            Fire();
            fireCooldown = 1f / fireRate;
        }
    }

    void Fire()
    {
        GameObject bullet = PoolManager.Instance.SpawnFromPool(bulletTag, firePoint.position, firePoint.rotation);
        if (bullet == null) return;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.right * bulletSpeed;
        }
    }
}
