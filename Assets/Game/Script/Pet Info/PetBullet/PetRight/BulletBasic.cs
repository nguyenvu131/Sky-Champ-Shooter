using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBasic : MonoBehaviour {

	public float speed = 10f;
    public float damage = 1f;

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
        }
    }
}
