using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAsteroid : MonoBehaviour {

	public GameObject smallAsteroidPrefab;
    private float speed = 1.8f;

    public void Init(float moveSpeed)
    {
        speed = moveSpeed;
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (transform.position.y < -6f)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet") || other.CompareTag("Player"))
        {
            SplitIntoSmall();
            Destroy(gameObject);
        }
    }

    void SplitIntoSmall()
    {
        if (smallAsteroidPrefab == null) return;

        for (int i = -1; i <= 1; i++)
        {
            GameObject small = Instantiate(
                smallAsteroidPrefab,
                transform.position,
                Quaternion.identity,
                transform.parent
            );
            small.AddComponent<Asteroid>().Init(2.5f + Random.Range(-0.5f, 0.5f));
            small.GetComponent<Rigidbody2D>().velocity = new Vector2(i * 1f, -2f);
        }
    }
}
