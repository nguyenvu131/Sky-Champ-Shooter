using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Đạn tự tìm Player
public class HomingBulletMonster : BaseEnemyBullet
{
    public float turnSpeed = 5f;

    protected override void Init()
    {
        moveDirection = transform.up;
    }

    protected override void Move()
    {
        if (target == null) return;

        Vector3 dir = (target.position - transform.position).normalized;
        moveDirection = Vector3.Lerp(moveDirection, dir, Time.deltaTime * turnSpeed);
        transform.up = moveDirection;
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}
