using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscortEnemy : MonoBehaviour {

	public float speed = 2.5f;
    private Vector2 moveDir = Vector2.down;
    private Transform player;
    public GameObject bulletPrefab;
    public float shootDelay = 1.5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("Shoot", shootDelay, 1.5f);
    }

    public void SetTargetDirection(Vector2 dir)
    {
        moveDir = dir.normalized;
    }

    void Update()
    {
        transform.Translate(moveDir * speed * Time.deltaTime);

        if (transform.position.y < -6f)
            Destroy(gameObject);
    }

    void Shoot()
    {
        if (bulletPrefab == null || player == null) return;

        Vector3 dir = (player.position - transform.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<EnemyBullet17>().SetDirection(dir);
    }
}
