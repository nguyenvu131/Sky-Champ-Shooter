using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSideAmbush : MonoBehaviour {

	public float speed = 3.5f;
    public Vector2 moveDirection = Vector2.down;
    public GameObject bulletPrefab;
    public float shootDelay = 0.5f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("ShootDiagonal", shootDelay, 1.5f);
    }

    public void SetDirection(Vector2 dir)
    {
        moveDirection = dir.normalized;
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x) > 10 || transform.position.y < -6)
            Destroy(gameObject);
    }

    void ShootDiagonal()
    {
        if (bulletPrefab == null || player == null) return;

        // Đạn bắn theo hướng tương tự hướng di chuyển
        Vector2 bulletDir = moveDirection.normalized;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<EnemyBullet16>().SetDirection(bulletDir);
    }
}
