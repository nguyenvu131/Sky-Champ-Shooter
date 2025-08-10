using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel1 : BossBase
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    private float fireTimer;
	

    public new void Start()
    {
        bossName = "Laser Shooter Lv1";
        bossLevel = 1;
        maxHealth = 10;
        moveSpeed = 2f;
        InitBoss();
		
    }

    void Update()
    {
		Debug.Log("Monster Lv" + bossLevel + 
                  " | HP: " + currentHealth + 
                  " | DMG: " + stats.damage);
        if (isDefeated) return;
        BossAttackPattern();
    }

    protected override void BossAttackPattern()
    {
		if (bulletPrefab == null || firePoint == null) return; // Chặn khi mất reference
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireRate)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            fireTimer = 0f;
        }

        rb.velocity = new Vector2(Mathf.Sin(Time.time) * moveSpeed, 0);
    }
	
	
}
