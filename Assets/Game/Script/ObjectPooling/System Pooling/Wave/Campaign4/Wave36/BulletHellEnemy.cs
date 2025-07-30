using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHellEnemy : MonoBehaviour {

	public GameObject bulletPrefab;
    public float shootInterval = 2f;
    public float rotationSpeed = 90f; // độ xoay mỗi giây
    public int bulletsPerWave = 12;
    public float moveSpeed = 1.2f;

    private float angleOffset = 0f;

    void Start()
    {
        InvokeRepeating("ShootSpiral", 1f, shootInterval);
    }

    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        if (transform.position.y < -6f)
            Destroy(gameObject);
    }

    void ShootSpiral()
    {
        for (int i = 0; i < bulletsPerWave; i++)
        {
            float angle = (360f / bulletsPerWave) * i + angleOffset;
            Vector3 dir = Quaternion.Euler(0, 0, angle) * Vector3.up;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = dir * 3f;
        }

        angleOffset += rotationSpeed * Time.deltaTime; // tăng xoay để tạo xoắn
    }
}
