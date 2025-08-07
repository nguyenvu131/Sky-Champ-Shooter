using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossQuantumCore : MonoBehaviour {

	public float maxHP = 1000;
    private float currentHP;

    public GameObject rotatingBullet;
    public GameObject portalEffect;
    public GameObject laserBeam;
    public GameObject bulletPrefab;

    private int phase = 1;
    private float moveSpeed = 1.5f;

    void Start()
    {
        currentHP = maxHP;
        StartCoroutine(BossRoutine());
    }

    void Update()
    {
        // Di chuyển chậm trái phải
        transform.position += Vector3.right * Mathf.Sin(Time.time) * moveSpeed * Time.deltaTime;
    }

    IEnumerator BossRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        
        while (currentHP > 0)
        {
            if (phase == 1)
            {
                yield return StartCoroutine(Phase1_RotatingBullets());
                if (currentHP < maxHP * 0.66f) phase = 2;
            }
            else if (phase == 2)
            {
                yield return StartCoroutine(Phase2_PortalDash());
                if (currentHP < maxHP * 0.33f) phase = 3;
            }
            else
            {
                yield return StartCoroutine(Phase3_LaserAndHell());
            }

            yield return new WaitForSeconds(2f);
        }

        // Die
        Destroy(gameObject);
    }

    IEnumerator Phase1_RotatingBullets()
    {
        int waveCount = 5;
        for (int i = 0; i < waveCount; i++)
        {
            SpawnRotatingBullets();
            yield return new WaitForSeconds(2f);
        }
    }

    void SpawnRotatingBullets()
    {
        int bulletCount = 12;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * 360f / bulletCount;
            Quaternion rot = Quaternion.Euler(0, 0, angle);
            GameObject bullet = Instantiate(rotatingBullet, transform.position, rot);
            bullet.AddComponent<RotatingBullet>().Init(angle);
        }
    }

    IEnumerator Phase2_PortalDash()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject portal = Instantiate(portalEffect, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);

            float randX = Random.Range(-2f, 2f);
            transform.position = new Vector3(randX, 4.5f, 0f);
            Destroy(portal);

            SpawnRadialBullets(16);
            yield return new WaitForSeconds(1.5f);
        }
    }

    void SpawnRadialBullets(int count)
    {
        for (int i = 0; i < count; i++)
        {
            float angle = i * 360f / count;
            Quaternion rot = Quaternion.Euler(0, 0, angle);
            GameObject b = Instantiate(bulletPrefab, transform.position, rot);
            b.AddComponent<BulletStraight>().Init(rot * Vector3.up);
        }
    }

    IEnumerator Phase3_LaserAndHell()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject laser = Instantiate(laserBeam, transform.position + new Vector3(0, -0.5f, 0), Quaternion.identity);
            Destroy(laser, 2f);

            SpawnRadialBullets(24);
            yield return new WaitForSeconds(2f);
        }
    }

    public void TakeDamage(float dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0)
        {
            // Chết
            Destroy(gameObject);
        }
    }
}
