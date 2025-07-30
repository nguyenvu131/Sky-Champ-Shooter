using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossAttack : MonoBehaviour {

	public GameObject bulletPrefab;
    public float fireRate = 2f;
    private float fireTimer;

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            FireBullet();
            fireTimer = 0f;
        }
    }

    void FireBullet()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}
