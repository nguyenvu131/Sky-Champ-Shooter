using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	public float fallSpeed = 4f;

    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // Tự hủy nếu rơi quá thấp
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Gây sát thương nếu có hệ thống máu người chơi
            // other.GetComponent<PlayerHealth>()?.TakeDamage(20);

            Destroy(gameObject);
        }
    }
}
