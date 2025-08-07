using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShoot7 : MonoBehaviour {

	public GameObject bullet;
    public Transform firePoint;
    public float fireRate = 1.5f; // Thời gian giữa các lần bắn
    public float bulletSpeed = 5f;

    private float fireTimer = 0f;
    private Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        if (player == null) return;

        fireTimer += Time.deltaTime;
        if (fireTimer >= fireRate)
        {
            FireBullet();
            fireTimer = 0f;
        }
    }

    void FireBullet()
    {
        bullet = BulletPoolManager.Instance.SpawnBullet("BulletMonster7", transform.position);
        // Đã được Active trong ObjectPooler
        Vector2 dir = (player.position - transform.position).normalized;
        // bullet.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;
    }
}
