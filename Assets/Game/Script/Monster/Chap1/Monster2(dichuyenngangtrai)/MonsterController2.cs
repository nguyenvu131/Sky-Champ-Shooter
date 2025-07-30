using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MonsterStats))]
public class MonsterController2 : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float detectionRange = 5f;
    public float attackRange = 1.5f;
    public float attackCooldown = 2f;

    private Transform player;
    private MonsterStats stats;
    private Animator animator;
    private float lastAttackTime;
    private bool isDead = false;

    private enum State
    {
        Idle,
        Chasing,
        Attacking
    }

    private State currentState = State.Idle;

    void Start()
    {
        stats = GetComponent<MonsterStats>();
        animator = GetComponent<Animator>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        if (isDead || player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        switch (currentState)
        {
            case State.Idle:
                if (distance <= detectionRange)
                {
                    currentState = State.Chasing;
                }
                break;

            case State.Chasing:
                if (distance > detectionRange)
                {
                    currentState = State.Idle;
                    animator.SetBool("isMoving", false);
                }
                else if (distance <= attackRange)
                {
                    currentState = State.Attacking;
                    animator.SetBool("isMoving", false);
                }
                else
                {
                    MoveTo(player.position);
                }
                break;

            case State.Attacking:
                if (distance > attackRange)
                {
                    currentState = State.Chasing;
                }
                else
                {
                    if (Time.time - lastAttackTime > attackCooldown)
                    {
                        lastAttackTime = Time.time;
                        Attack();
                    }
                }
                break;
        }
    }

    void MoveTo(Vector3 target)
    {
        Vector3 dir = (target - transform.position).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;

        // Optional: flip sprite if 2D
        if (dir.x != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = dir.x > 0 ? 1 : -1;
            transform.localScale = scale;
        }

        animator.SetBool("isMoving", true);
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        Debug.Log("Monster attacks!");
        // Gây damage nếu có hệ thống PlayerHealth
        // player.GetComponent<PlayerHealth>().TakeDamage(stats.attack);
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return;

        stats.currentHP -= amount;
        animator.SetTrigger("Hurt");

        if (stats.currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetTrigger("Die");
        animator.SetBool("isMoving", false);

        // Vô hiệu hóa collider hoặc các thành phần khác nếu cần
        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        // Xoá sau 2 giây
        Destroy(gameObject, 2f);
    }
}
