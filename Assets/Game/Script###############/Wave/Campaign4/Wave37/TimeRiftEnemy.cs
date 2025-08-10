using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRiftEnemy : MonoBehaviour {

	public GameObject bulletPrefab;
    public float moveSpeed = 1.5f;
    public float shootInterval = 2f;
    public float blinkInterval = 3f;

    private float blinkTimer = 0f;

    void Start()
    {
        InvokeRepeating("Shoot", 1f, shootInterval);
    }

    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        blinkTimer += Time.deltaTime;
        if (blinkTimer >= blinkInterval)
        {
            Blink();
            blinkTimer = 0f;
        }

        if (transform.position.y < -6f)
            Destroy(gameObject);
    }

    void Shoot()
    {
        if (bulletPrefab != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = Vector2.down * 4f;
        }
    }

    void Blink()
    {
        Vector3 newPos = new Vector3(
            Mathf.Clamp(transform.position.x + Random.Range(-2f, 2f), -3f, 3f),
            transform.position.y + Random.Range(0.5f, 1.5f),
            0f
        );

        transform.position = newPos;
    }
}
