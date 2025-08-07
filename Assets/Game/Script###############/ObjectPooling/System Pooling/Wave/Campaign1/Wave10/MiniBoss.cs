using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : MonoBehaviour {

	public float moveSpeed = 1f;
    public int maxHP = 500;
    [SerializeField] private GameObject bulletPrefab;
    public float fireRate = 2f;

    private int currentHP;
    private float fireCooldown;

    void Start()
    {
        currentHP = maxHP;
        fireCooldown = fireRate;
    }

    void Update()
    {
        // Di chuyển từ từ xuống (chỉ 1 lần)
        if (transform.position.y > 3f)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }

        // Bắn đạn
        fireCooldown -= Time.deltaTime;
        if (fireCooldown <= 0f)
        {
            Fire();
            fireCooldown = fireRate;
        }
    }

    void Fire()
    {
        // Bắn 3 đạn theo hình nón
        Vector3 pos = transform.position;
        SpawnBullet(pos, Vector2.down);
        SpawnBullet(pos, (Vector2.down + Vector2.left * 0.5f).normalized);
        SpawnBullet(pos, (Vector2.down + Vector2.right * 0.5f).normalized);
    }

    void SpawnBullet(Vector3 pos, Vector2 dir)
    {
		if (bulletPrefab == null)
		{
			// Debug.LogWarning("bulletPrefab is null or destroyed");
			return;
		}
        GameObject bullet = Instantiate(bulletPrefab, pos, Quaternion.identity);
        bullet.GetComponent<Bullet_Enemy>().SetDirection(dir);
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Add explosion effect, drop item, shake camera
        Destroy(gameObject);
    }
}
