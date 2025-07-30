using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Đạn bắn lan nhiều hướng
public class SpreadBullet : BaseEnemyBullet
{
    protected override void Init()
    {
        moveDirection = transform.up;
    }

    protected override void Move()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}

// public void FireSpread(int bulletCount, float spreadAngle)
// {
    // float startAngle = -spreadAngle / 2f;
    // float angleStep = spreadAngle / (bulletCount - 1);

    // for (int i = 0; i < bulletCount; i++)
    // {
        // float angle = startAngle + angleStep * i;
        // Quaternion rot = Quaternion.Euler(0, 0, angle);
        // GameObject bullet = BulletPool.Instance.GetBullet("SpreadBullet");
        // bullet.transform.position = firePoint.position;
        // bullet.transform.rotation = firePoint.rotation * rot;
        // bullet.GetComponent<BaseEnemyBullet>().SetTarget(player);
    // }
// }
