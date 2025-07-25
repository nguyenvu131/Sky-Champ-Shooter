using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooterMonster : MonoBehaviour
{
    public string bulletID = "Normal";
    public Transform firePoint;
    public float fireRate = 0.25f;
    private float fireTimer;

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && fireTimer >= fireRate)
        {
            Shoot();
            fireTimer = 0f;
        }
    }

    void Shoot()
    {
        PlayerBulletPoolManager.Instance.SpawnBullet(bulletID, firePoint.position, firePoint.rotation);
    }
}
