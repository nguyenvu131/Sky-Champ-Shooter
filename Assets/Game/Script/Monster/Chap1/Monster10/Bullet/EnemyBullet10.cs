using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet10 : MonoBehaviour {

	 public float damage = 7f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
			if (player != null)
			{
				player.TakeDamage(damage);
			}
            // Destroy(gameObject);
        }
    }
}
