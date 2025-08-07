using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfernoTitanBoss : MonoBehaviour {

	public float maxHP = 1000f;
    public GameObject bulletPrefab;
    public GameObject summonEnemyPrefab;
    public Transform[] firePoints;
    public GameObject explosionEffect;

    private float currentHP;
    private int currentPhase = 1;
    private float shootTimer = 0f;
    private float shootInterval = 2f;

    void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            switch (currentPhase)
            {
                case 1: ShootSingle(); break;
                case 2: ShootCircle(); break;
                case 3: ShootRadial(); break;
            }

            shootTimer = shootInterval;
        }

        UpdatePhase();
    }

    void UpdatePhase()
    {
        float hpPercent = currentHP / maxHP;

        if (hpPercent <= 0.4f && currentPhase != 3)
        {
            currentPhase = 3;
            shootInterval = 1f;
        }
        else if (hpPercent <= 0.7f && currentPhase != 2)
        {
            currentPhase = 2;
            shootInterval = 1.5f;
        }
    }

    // Phase 1: Bắn đơn + gọi quái con
    void ShootSingle()
    {
        if (summonEnemyPrefab != null)
        {
            Instantiate(summonEnemyPrefab, transform.position + Vector3.down * 1.5f, Quaternion.identity);
        }

        Vector3 dir = Vector3.down;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<EnemyBullet30>().Init(dir);
    }

    // Phase 2: Bắn 8 hướng
    void ShootCircle()
    {
        int count = 8;
        for (int i = 0; i < count; i++)
        {
            float angle = i * 360f / count;
            Vector3 dir = Quaternion.Euler(0, 0, angle) * Vector3.down;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<EnemyBullet30>().Init(dir);
        }
    }

    // Phase 3: Bullet Hell dạng hoa sen
    void ShootRadial()
    {
        int rings = 3;
        int bulletsPerRing = 12;
        float spreadAngle = 20f;

        for (int r = 0; r < rings; r++)
        {
            float angleOffset = r * spreadAngle;
            for (int i = 0; i < bulletsPerRing; i++)
            {
                float angle = angleOffset + (360f / bulletsPerRing) * i;
                Vector3 dir = Quaternion.Euler(0, 0, angle) * Vector3.down;
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<EnemyBullet30>().Init(dir);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;

        if (currentHP <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        if (explosionEffect != null)
            Instantiate(explosionEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
