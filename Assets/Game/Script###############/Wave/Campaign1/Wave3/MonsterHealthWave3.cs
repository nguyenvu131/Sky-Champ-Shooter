using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealthWave3 : MonoBehaviour {

	public int hp = 10;
    public GameObject explosionEffectPrefab;
    public float explosionRadius = 2f;
    public int explosionDamage = 20;

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Explode();
        }
    }

    void Explode()
    {
        // Hiệu ứng nổ
        if (explosionEffectPrefab != null)
        {
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        }

        // Gây sát thương vùng
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                // Gây sát thương cho Player (nếu có hệ thống PlayerHealth)
                // hit.GetComponent<PlayerHealth>()?.TakeDamage(explosionDamage);
            }
        }

        Destroy(gameObject);
    }
}
