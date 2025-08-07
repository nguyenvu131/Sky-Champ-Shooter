using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3 : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 moveDirection;
	public PlayerStats stats;

    public void SetDirection(Vector2 dir)
    {
        moveDirection = dir.normalized;
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
	
	void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("Player"))
			{

				PlayerStats player = other.GetComponent<PlayerStats>();
				if (player != null)
				{
					player.TakeDamage(stats.damage);
				}
				
				// Gây sát thương hoặc hiệu ứng ở đây nếu cần
				// Destroy(gameObject);
				gameObject.SetActive(false);
			}
			else if (other.CompareTag("Wall") || other.CompareTag("Border"))
			{
				// Destroy(gameObject);
				gameObject.SetActive(false);
			}
		}
	
	
    void OnBecameInvisible()
    {
        // Destroy(gameObject);
    }
}
