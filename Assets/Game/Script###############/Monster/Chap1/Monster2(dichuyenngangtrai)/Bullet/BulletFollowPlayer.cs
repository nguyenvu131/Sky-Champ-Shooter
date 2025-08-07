using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFollowPlayer : MonoBehaviour 
{

	public float speed = 5f;
    private Transform player;
	public PlayerStats stats;
	
    void Start()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        if (target != null)
        {
            player = target.transform;

            // Tính hướng từ đạn tới player
            Vector3 dir = (player.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        else
        {
            Debug.LogWarning("Không tìm thấy Player!");
			gameObject.SetActive(false);
            // Destroy(gameObject); // tự hủy nếu không có player
			
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            PlayerManager player = other.GetComponent<PlayerManager>();
			// PlayerStats stats = player.stats;
            if (player != null)
            {
                player.TakeDamage(stats.damage);
            }
            
            // Gây sát thương hoặc hiệu ứng ở đây nếu cần
			
            // Destroy(gameObject);
			gameObject.SetActive(false);
        }
		
        // if (other.CompareTag("Wall") || other.CompareTag("Border"))
        // {
            // Destroy(gameObject);
        // }
    }
}
