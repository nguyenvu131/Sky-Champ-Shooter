using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Nổ AOE khi trúng
public class ExplodingBulletMonster : BaseEnemyBullet
{
    public float explosionRadius = 2f;

    protected override void Init()
    {
        moveDirection = transform.up;
    }

    protected override void Move()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Explode();
        }
    }

    void Explode()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                PlayerHealth hp = hit.GetComponent<PlayerHealth>();
                if (hp != null) hp.TakeDamage(damage);
            }
        }

        Disable();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}

