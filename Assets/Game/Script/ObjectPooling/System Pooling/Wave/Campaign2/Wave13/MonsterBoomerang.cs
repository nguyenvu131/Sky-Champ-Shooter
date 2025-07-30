using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBoomerang : MonoBehaviour {

	public float speed = 2f;
    public float turnBackY = -3f;            // Khi đến Y này thì quay lại
    public float returnSpeed = 3.5f;
    public float destroyY = 7f;              // Hủy khi ra khỏi màn hình trên
    private bool hasTurnedBack = false;
    private Transform player;
	
	public GameObject bulletPrefab;
	public float shootInterval = 1.5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
		// Chỉ bắn khi đã quay lại
		InvokeRepeating("Shoot", 0f, shootInterval);
    }

    void Update()
    {
        if (!hasTurnedBack)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;

            if (transform.position.y <= turnBackY)
            {
                hasTurnedBack = true;
            }
        }
        else
        {
            if (player != null)
            {
                Vector3 dir = (player.position - transform.position).normalized;
                transform.position += dir * returnSpeed * Time.deltaTime;
            }

            if (transform.position.y > destroyY)
            {
                Destroy(gameObject);
            }
        }
    }
	
	void Shoot()
{
    if (hasTurnedBack && player != null && bulletPrefab != null)
    {
        Vector3 dir = (player.position - transform.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<EnemyBoomerangBullet>().SetDirection(dir);
    }
}
}
