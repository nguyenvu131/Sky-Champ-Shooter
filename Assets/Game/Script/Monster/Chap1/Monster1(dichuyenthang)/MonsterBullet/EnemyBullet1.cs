using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet1 : MonoBehaviour {

	public float lifeTime = 5f;
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
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
			
            // Gây sát thương ở đây
            gameObject.SetActive(false);
        }
    }
}
