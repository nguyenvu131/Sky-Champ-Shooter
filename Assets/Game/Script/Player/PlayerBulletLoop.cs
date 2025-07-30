using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletLoop : MonoBehaviour {

	
	public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.2f;
    private float nextFire;
	public float fireCooldown = 0f;

    public int baseDamage = 10;
    public float critChance = 0.1f;
    public float critMultiplier = 2f;
	
	
    void Update()
    {
        if (Time.time > nextFire)
        {
            Shoot();
            nextFire = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = PlayerBulletPoolManager.Instance.SpawnBullet("normal", firePoint.position, firePoint.rotation);
		bullet.GetComponent<Bullet>().SetDirection(Vector2.up);
		
    }
}
