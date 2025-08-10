using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet25 : MonoBehaviour {

	public float speed = 7f;
    private Vector3 direction;

    public void Init(Vector3 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (transform.position.magnitude > 20f)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Gây damage ở đây nếu có
            Destroy(gameObject);
        }
    }
}
