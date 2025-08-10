using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel10 : BossBase
{
    public GameObject bulletPrefab;
    public GameObject laserPrefab;
    public GameObject summonEnemyPrefab;
    public Transform[] firePoints;

    private float attackTimer;
    private int phase;

    public new void Start()
    {
        bossName = "Omega Annihilator Lv10";
        bossLevel = 10;
        maxHealth = 5000;
        moveSpeed = 4f;
        InitBoss();
    }

    void Update()
    {
        if (isDefeated) return;

        if (currentHealth > maxHealth * 0.6f) phase = 1;
        else if (currentHealth > maxHealth * 0.3f) phase = 2;
        else phase = 3;

        BossAttackPattern();
    }

    protected override void BossAttackPattern()
    {
        attackTimer += Time.deltaTime;
        switch (phase)
        {
            case 1:
                if (attackTimer > 1f) FireBullets();
                break;
            case 2:
                if (attackTimer > 1.5f) FireLaser();
                break;
            case 3:
                if (attackTimer > 2f) SummonEnemies();
                break;
        }
    }

    private void FireBullets()
    {
        for (int i = 0; i < firePoints.Length; i++)
        {
            Instantiate(bulletPrefab, firePoints[i].position, firePoints[i].rotation);
        }
        attackTimer = 0f;
    }

    private void FireLaser()
    {
        Instantiate(laserPrefab, transform.position, Quaternion.identity);
        attackTimer = 0f;
    }

    private void SummonEnemies()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(summonEnemyPrefab, transform.position + new Vector3(i, -2, 0), Quaternion.identity);
        }
        attackTimer = 0f;
    }
}
