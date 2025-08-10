using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Tia laser dài, sát thương liên tục
public class LaserBullet : BaseEnemyBullet
{
    public LineRenderer line;
    public float damageInterval = 0.5f;
    private float damageTimer;

    protected override void Init()
    {
        damageTimer = 0f;
        if (!line.enabled) line.enabled = true;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position + transform.up * 10f); // Laser dài 10 đơn vị
    }

    protected override void Move()
    {
        damageTimer += Time.deltaTime;
        if (damageTimer >= damageInterval)
        {
            damageTimer = 0f;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 10f);
            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                PlayerHealth hp = hit.collider.GetComponent<PlayerHealth>();
                if (hp != null) hp.TakeDamage(damage);
            }
        }
    }

    protected override void Disable()
    {
        line.enabled = false;
        base.Disable();
    }
}