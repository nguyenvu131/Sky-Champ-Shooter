using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemyBullet : MonoBehaviour
{
    [Header("Base Bullet Stats")]
    public float speed = 5f;
    public int damage = 10;
    public float lifeTime = 5f;

    protected Transform target;
    protected Vector3 moveDirection;

    protected virtual void OnEnable()
    {
        Invoke("Disable", lifeTime);
        Init();
    }

    protected virtual void Update()
    {
        Move();
    }

    public virtual void SetTarget(Transform player)
    {
        target = player;
    }

    protected abstract void Init();     // Để class con override
    protected abstract void Move();     // Để class con override

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth hp = other.GetComponent<PlayerHealth>();
            if (hp != null) hp.TakeDamage(damage);
            Disable();
        }
    }

    protected virtual void Disable()
    {
        CancelInvoke();
        gameObject.SetActive(false);
    }
}
