using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBuffItem : MonoBehaviour
{
    public int buffLevel = 3;
    public float buffDuration = 10f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShooting ps = other.GetComponent<PlayerShooting>();
            if (ps != null)
            {
                ps.TemporaryUpgradeBullet(buffLevel, buffDuration);
            }

            // Có thể thêm hiệu ứng/âm thanh tại đây
            Destroy(gameObject);
        }
    }
}
