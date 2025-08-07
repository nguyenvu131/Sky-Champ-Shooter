using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting25 : MonoBehaviour {

	public GameObject bulletPrefab;
    public float shootInterval = 2f;
    private float shootTimer;

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
            ShootAtPlayer();
            shootTimer = shootInterval;
        }
    }

    void ShootAtPlayer()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<EnemyBullet25>().Init(dir);
    }
}
