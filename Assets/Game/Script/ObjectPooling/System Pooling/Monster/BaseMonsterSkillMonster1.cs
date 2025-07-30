using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonsterSkillMonster1 : MonoBehaviour
{
    public string skillID;
    public float duration = 2f;
    protected float timer;

    protected virtual void OnEnable()
    {
        timer = 0f;
    }

    protected virtual void Update()
    {
        timer += Time.deltaTime;
        if (timer >= duration)
        {
            MonsterSkillPoolManager.Instance.ReturnToPool(gameObject);
        }
    }

    public virtual void Activate(Vector3 direction)
    {
        // Override cho skill bay (projectile), AOE, v.v.
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Apply damage, debuff, etc.
        }
    }
}
