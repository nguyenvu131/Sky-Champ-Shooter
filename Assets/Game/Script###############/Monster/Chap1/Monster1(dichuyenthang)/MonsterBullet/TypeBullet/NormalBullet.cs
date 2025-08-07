using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Đạn bay thẳng cơ bản
public class NormalBullet : BaseEnemyBullet
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
