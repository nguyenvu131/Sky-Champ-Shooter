using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy2 : MonoBehaviour {

	public GameObject bulletPrefab;        // Prefab đạn
    public float fireRate = 2f;            // Thời gian giữa các lần bắn
    private float nextFireTime = 0f;

	public GameObject bullet;
    private Transform player;

    void Start()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        if (target != null)
        {
            player = target.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        if (Time.time >= nextFireTime)
        {
            FireAtPlayer();
            nextFireTime = Time.time + fireRate;
        }
    }

    void FireAtPlayer()
    {
        // Tính hướng đến player
        Vector3 direction = (player.position - transform.position).normalized;

        // Tính góc xoay (rotation) từ vector hướng
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

        // Tạo đạn tại vị trí quái, xoay theo hướng
        bullet = Instantiate(bulletPrefab, transform.position, rotation);
        // bullet sẽ tự bay theo hướng (đã xử lý trong BulletFollowPlayer)
    }
}
