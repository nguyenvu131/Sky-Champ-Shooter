using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet7 : MonoBehaviour {

	public float speed = 10f;
    public int damage = 1;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Tự huỷ nếu vượt quá màn hình
        if (transform.position.y > 10f)
            gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Monster monster = other.GetComponent<Monster>();
            if (monster != null)
            {
                monster.TakeDamage(damage);
            }

            gameObject.SetActive(false); // Tắt đạn
        }
    }
}
