using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Làm chậm người chơi
public class SlowBullet : BaseEnemyBullet
{
    public float slowDuration = 2f;
    public float slowFactor = 0.5f;

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
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.ApplySlow(slowFactor, slowDuration);
            }
            Disable();
        }
    }
}
