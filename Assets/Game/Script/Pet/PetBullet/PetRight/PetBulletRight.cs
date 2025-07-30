using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetBulletRight : MonoBehaviour {

	public float speed = 10f;
    public float damage = 1f;
	public string poolKey; 

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
		// Nếu đi quá xa màn hình thì ẩn
		if (transform.position.y > 15f || transform.position.y < -10f)
		{
			gameObject.SetActive(false);
		}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // other.GetComponent<Enemy>().TakeDamage(damage);
            // Destroy(gameObject);
			if (other.CompareTag("Enemy"))
        {
            Monster enemy = other.GetComponent<Monster>();
            if (enemy != null)
                enemy.TakeDamage(damage);

            Return();
        }
        }
    }
	
	// ✅ Hàm Return trả đạn về pool
    void Return()
    {
        if (!string.IsNullOrEmpty(poolKey))
        {
            ObjectPooler.Instance.ReturnToPool(poolKey, gameObject);
        }
        else
        {
            gameObject.SetActive(false); // fallback nếu không có key
        }
    }
}
