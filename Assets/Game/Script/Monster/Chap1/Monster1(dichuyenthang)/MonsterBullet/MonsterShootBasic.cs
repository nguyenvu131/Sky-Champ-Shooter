using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShootBasic : MonoBehaviour {

	public float shootInterval = 2f;             // Thời gian giữa mỗi lần bắn
    public string bulletID = "EnemyBullet1";     // ID của đạn dùng trong pool
    public float bulletSpeed = 5f;

    private float shootTimer = 0f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        shootTimer = shootInterval;
    }

    void Update()
    {
        if (player == null) return;

        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            Shoot();
            shootTimer = shootInterval;
        }
    }

    void Shoot()
    {
        // Lấy hướng từ quái đến người chơi
        Vector3 dir = (player.position - transform.position).normalized;

        // Lấy đạn từ pool
        GameObject bullet = BulletPoolManager.Instance.SpawnBullet(bulletID, transform.position);
        if (bullet != null)
        {
            bullet.transform.rotation = Quaternion.LookRotation(Vector3.forward, dir);
            bullet.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;
        }
    }
}
