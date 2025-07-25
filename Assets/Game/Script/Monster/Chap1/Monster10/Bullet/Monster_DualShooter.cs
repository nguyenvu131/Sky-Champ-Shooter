using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_DualShooter : MonoBehaviour {

	public float hp = 200f;
    public float speed = 1.8f;
    public float fireRate = 2f;
    public float bulletSpeed = 3.5f;
    public GameObject bulletPrefab;
    public Transform firePointLeft;
    public Transform firePointRight;

    private float fireTimer;

    void Update()
    {
        MoveDown();

        fireTimer += Time.deltaTime;
        if (fireTimer >= fireRate)
        {
            fireTimer = 0f;
            Fire();
        }
    }

    void MoveDown()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void Fire()
    {
        GameObject bulletL = Instantiate(bulletPrefab, firePointLeft.position, Quaternion.identity);
        GameObject bulletR = Instantiate(bulletPrefab, firePointRight.position, Quaternion.identity);

        bulletL.GetComponent<Rigidbody2D>().velocity = Vector2.down * bulletSpeed;
        bulletR.GetComponent<Rigidbody2D>().velocity = Vector2.down * bulletSpeed;
    }

    public void TakeDamage(float dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        DropItemPoolManager.Instance.SpawnItem("Coin", transform.position);
        Destroy(gameObject);
    }
}
