using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet9 : MonoBehaviour {

	public float lifeTime = 5f;
	public float damage;

    void Start()
    {
        // Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
			if (player != null)
			{
				player.TakeDamage(damage); // Gây 10 damage
			}
			// Gây sát thương nếu cần
            // Destroy(gameObject);
			gameObject.SetActive(false);
			
        }
    }
}
