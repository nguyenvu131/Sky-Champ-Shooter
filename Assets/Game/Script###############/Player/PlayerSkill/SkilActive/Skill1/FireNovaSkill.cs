using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireNovaSkill : MonoBehaviour
{
    public float damage = 50f;            // Sát thương gây ra
    public float explosionRadius = 5f;    // Bán kính tác động
    public float duration = 1f;           // Thời gian tồn tại của hiệu ứng

    void Start()
    {
        // Gây sát thương ngay lập tức khi được sinh ra
        DealDamage();

        // Hủy đối tượng sau một thời gian để không tồn tại mãi
        Destroy(gameObject, duration);
    }

    void DealDamage()
    {
        // Tìm tất cả collider trong bán kính
        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                Monster enemy = hit.GetComponent<Monster>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }

                // Hiệu ứng bị trúng đòn (nếu có)
                // EnemyHitEffect effect = hit.GetComponent<EnemyHitEffect>();
                // if (effect != null) effect.PlayHit();
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Hiển thị phạm vi tác động trong Editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
