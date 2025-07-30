using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetBulletLeft : MonoBehaviour {

	public float damage = 10f;
    public float lifeTime = 3f;
    private float timer;

    void OnEnable()
    {
        timer = lifeTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            PlayerBulletPoolManager.Instance.ReturnToPool(gameObject);
        }
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

            PlayerBulletPoolManager.Instance.ReturnToPool(gameObject);
        }
    }
}
