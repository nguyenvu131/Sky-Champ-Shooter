using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlazeyShooter : MonoBehaviour {

	 public Transform player;
    public GameObject fireballPrefab;
    public float followDistance = 1.5f;
    public float moveSpeed = 5f;

    public float attackRange = 6f;
    public float fireRate = 1.2f;
    public float damage = 10f;
    public float burnChance = 0.1f;
    public float burnDuration = 2f;
    public float burnDamagePerSecond = 5f;

    private float fireCooldown = 0f;

    void Start()
    {
        if (player == null)
            player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        // FollowPlayer();
        AttackNearestEnemy();
    }

    // void FollowPlayer()
    // {
        // Vector3 targetPos = player.position + new Vector3(followDistance, 1f, 0f);
        // transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * moveSpeed);
    // }

    void AttackNearestEnemy()
    {
        fireCooldown -= Time.deltaTime;
        if (fireCooldown > 0f) return;

        GameObject target = FindNearestEnemy();
        if (target != null)
        {
            FireAt(target.transform);
            fireCooldown = fireRate;
        }
    }

    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearest = null;
        float minDist = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist < attackRange && dist < minDist)
            {
                minDist = dist;
                nearest = enemy;
            }
        }

        return nearest;
    }

    void FireAt(Transform target)
    {
        GameObject bullet = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        FireballBullet fb = bullet.GetComponent<FireballBullet>();
        fb.SetTarget(target, damage, burnChance, burnDuration, burnDamagePerSecond);
    }
}
