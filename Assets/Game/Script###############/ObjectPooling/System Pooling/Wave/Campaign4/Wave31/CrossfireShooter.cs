using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossfireShooter : MonoBehaviour {

	public GameObject bulletPrefab;
    public float shootInterval = 1.5f;
    public float bulletSpeed = 4f;

    void Start()
    {
        StartCoroutine(ShootRoutine());
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            ShootDiagonalBullets();
            yield return new WaitForSeconds(shootInterval);
        }
    }

    void ShootDiagonalBullets()
    {
        FireBullet(new Vector2(1, 1).normalized);
        FireBullet(new Vector2(-1, 1).normalized);
        FireBullet(new Vector2(1, -1).normalized);
        FireBullet(new Vector2(-1, -1).normalized);
    }

    void FireBullet(Vector2 dir)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;
    }
}
