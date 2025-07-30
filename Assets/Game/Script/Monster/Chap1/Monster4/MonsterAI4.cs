using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI4 : MonoBehaviour {

	public MonsterStats stats;
    private Transform player;
    private float shootTimer;
    private MonsterState state = MonsterState.Idle;
	public float speed = 0.5f;
	
	public bool isFollower = false;

    void OnEnable()
    {
        stats = GetComponent<MonsterStats>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // shootTimer = Random.Range(0f, stats.attackRate);
    }

    void Update()
    {
		if (isFollower) return;
		
        if (state == MonsterState.Die || player == null) return;

        AIBehavior();
    }

    void AIBehavior()
    {
        switch (state)
        {
            case MonsterState.Idle:
                if (Vector3.Distance(transform.position, player.position) < 10f)
                    state = MonsterState.Attack;
                break;

            case MonsterState.Attack:
                MoveTowardPlayer();
                ShootLogic();
                break;

            case MonsterState.Evade:
                EvadePlayer();
                break;
        }
    }

    void MoveTowardPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void ShootLogic()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            Shoot();
            // shootTimer = stats.attackRate;
        }
    }

    void Shoot()
    {
        // GameObject bullet = ObjectPooler.Instance.Spawn(stats.bulletPrefab.tag, transform.position, Quaternion.identity);
        // bullet.GetComponent<BulletMonster>().Init(stats.attack, transform.up);
    }

    void EvadePlayer()
    {
        // Di chuyển né tránh theo hướng ngẫu nhiên
    }
}
