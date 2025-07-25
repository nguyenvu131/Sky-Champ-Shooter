using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponLevel weaponData;
    public Transform firePoint;
    public int weaponLevel = 0;

    private float fireCooldown = 0f;

    public bool autoFire = true; // Bật auto fire mặc định

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

        if (weaponLevel < 0 || weaponLevel >= weaponData.bulletPrefabs.Length) return;

        // Instantiate đạn theo cấp độ
        GameObject bullet = Instantiate(weaponData.bulletPrefabs[weaponLevel], firePoint.position, firePoint.rotation);

        // Truyền damage nếu đạn có script xử lý
        BulletBasic bulletScript = bullet.GetComponent<BulletBasic>();
        if (bulletScript != null)
        {
            bulletScript.damage = weaponData.damages[weaponLevel];
        }

        fireCooldown = weaponData.fireRates[weaponLevel];
    }

    public void UpgradeWeapon()
    {
        if (weaponLevel < weaponData.bulletPrefabs.Length - 1)
        {
            weaponLevel++;
        }
    }
}
