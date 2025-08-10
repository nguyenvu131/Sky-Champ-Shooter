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
			PetBulletHoming bulletScript = bullet.GetComponent<PetBulletHoming>();
			if (bulletScript != null)
			{
				bulletScript.damage = damage;
				bulletScript.speed = weaponData.bulletSpeeds[weaponLevel]; // Nếu có tốc độ riêng theo level
				bulletScript.SetTarget(FindClosestEnemy());
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
	
	Transform FindClosestEnemy()
	{
		float closestDistance = Mathf.Infinity;
		Transform closestEnemy = null;

		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // đảm bảo quái có tag là "Enemy"
		Vector3 currentPos = firePoint.position;

		foreach (GameObject enemy in enemies)
		{
			float distance = Vector3.Distance(currentPos, enemy.transform.position);
			if (distance < closestDistance)
			{
				closestDistance = distance;
				closestEnemy = enemy.transform;
			}
		}

		return closestEnemy;
	}
}
