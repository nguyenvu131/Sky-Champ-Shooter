using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Enemy : MonoBehaviour {

	public float speed = 6f;
    private Vector2 direction = Vector2.down;
	public float damage;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.y < -6f || transform.position.y > 6f)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
			PlayerManager player = other.GetComponent<PlayerManager>();
			if (player != null)
			{
				player.TakeDamage(damage);
			}
            // other.GetComponent<PlayerHealth>()?.TakeDamage(20);
            Destroy(gameObject);
        }
    }
}
