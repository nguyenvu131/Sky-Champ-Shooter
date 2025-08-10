using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterZigzagShooter : MonoBehaviour {

	 public float moveSpeed = 2f;
    public float zigzagAmplitude = 1.5f;
    public float zigzagFrequency = 2f;
    public float shootInterval = 1.5f;
    public GameObject bulletPrefab;

    public Vector3 startPos;
    private float timer;
    private Transform player;

    void Start()
    {
        startPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("Shoot", 1f, shootInterval);
    }

    void Update()
    {
        float xOffset = Mathf.Sin(Time.time * zigzagFrequency) * zigzagAmplitude;
        transform.position += new Vector3(xOffset, -moveSpeed, 0f) * Time.deltaTime;
    }

    void Shoot()
    {
        if (bulletPrefab == null || player == null) return;

        Vector3 dir = (player.position - transform.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<EnemyBullet12>().SetDirection(dir);
    }
}
