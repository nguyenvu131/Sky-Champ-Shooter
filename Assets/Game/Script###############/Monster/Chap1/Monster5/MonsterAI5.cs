using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI5 : MonoBehaviour {

	public enum AIMode { Passive, Chase, Shoot }
    public AIMode mode = AIMode.Passive;

    public float moveSpeed = 2f;
    public float detectRange = 5f;
    public float shootInterval = 1.5f;
    public GameObject bulletPrefab;

    private Transform player;
    private float shootTimer = 0f;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        switch (mode)
        {
            case AIMode.Passive:
                MoveDown();
                break;
            case AIMode.Chase:
                ChasePlayer();
                break;
            case AIMode.Shoot:
                ChasePlayer();
                HandleShooting();
                break;
        }
    }

    void MoveDown()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }

    void ChasePlayer()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    void HandleShooting()
    {
        shootTimer += Time.deltaTime;
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= detectRange && shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}
