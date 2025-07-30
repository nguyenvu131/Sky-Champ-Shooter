using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetShooterRight : MonoBehaviour
{
    public WeaponLevel weaponData;
    public Transform firePoint;
    public int weaponLevel = 0;

    private float fireCooldown = 0f;

    public bool autoFire = true;

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (autoFire)
        {
            Fire();
        }
    }

    public void Fire()
    {
        if (fireCooldown > 0f) return;
        if (weaponLevel < 0 || weaponLevel >= weaponData.bulletIDs.Length) return;

        string bulletID = weaponData.bulletIDs[weaponLevel];
        float damage = weaponData.damages[weaponLevel];
        float fireRate = weaponData.fireRates[weaponLevel];

        GameObject bullet = PlayerBulletPoolManager.Instance.SpawnBullet(bulletID, firePoint.position, firePoint.rotation);

        if (bullet != null)
        {
            PetBulletRight bulletScript = bullet.GetComponent<PetBulletRight>();
            if (bulletScript != null)
            {
                bulletScript.damage = damage;
            }

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.right * bulletScript.speed;
            }
        }

        fireCooldown = fireRate;
    }

    public void UpgradeWeapon()
    {
        if (weaponLevel < weaponData.bulletIDs.Length - 1)
        {
            weaponLevel++;
        }
    }
}
