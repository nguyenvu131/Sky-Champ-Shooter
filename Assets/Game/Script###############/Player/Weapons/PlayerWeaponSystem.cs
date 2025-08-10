using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSystem : MonoBehaviour
{
    public Transform firePoint; // Vị trí bắn đạn
    public GameObject defaultBulletPrefab;

    [Header("Weapon Config")]
    public float fireRate = 0.5f;
    private float fireCooldown = 0f;

    [Header("Weapon Levels")]
    public int weaponLevel = 1;
    public List<GameObject> bulletLevels; // Đạn theo cấp độ

    [Header("Auto Fire")]
    public bool autoFire = true;

    void Update()
    {
        if (autoFire && fireCooldown <= 0f)
        {
            Fire();
            fireCooldown = fireRate;
        }

        if (fireCooldown > 0f)
        {
            fireCooldown -= Time.deltaTime;
        }
    }

    public void Fire()
    {
        GameObject bulletPrefab = GetBulletByLevel(weaponLevel);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // TODO: Play sound, VFX, etc.
    }

    GameObject GetBulletByLevel(int level)
    {
        if (bulletLevels != null && level - 1 < bulletLevels.Count)
            return bulletLevels[level - 1];
        return defaultBulletPrefab;
    }

    public void SetWeaponLevel(int level)
    {
        weaponLevel = Mathf.Clamp(level, 1, bulletLevels.Count);
    }

    public void UpgradeWeapon()
    {
        SetWeaponLevel(weaponLevel + 1);
    }

    public void SetFireRate(float newRate)
    {
        fireRate = newRate;
    }

    public void EnableAutoFire(bool enable)
    {
        autoFire = enable;
    }
}
