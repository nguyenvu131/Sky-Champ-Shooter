using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI6 : MonoBehaviour {

	private MonsterStats stats;
	public GameObject player;
	public float speed;

    void Start()
    {
        stats = GetComponent<MonsterStats>();
		if (player == null)
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            float damage = other.GetComponent<Bullet>().damage;
            stats.currentHP -= damage;

            if (stats.currentHP <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        gameObject.SetActive(false); // object pooling
    }
}
