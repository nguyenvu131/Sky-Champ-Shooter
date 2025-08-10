using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI3 : MonoBehaviour {
    public enum State {
        Idle,
        Move,
        Shoot,
        Retreat
    }

    private State currentState = State.Idle;
    private float stateTimer = 0f;

    private MonsterStats stats;
    public GameObject bulletPrefab;
    public Transform firePoint;

    void OnEnable() {
        stats = GetComponent<MonsterStats>();
        ChangeState(State.Move);
    }

    void Update() {
        if (stats == null || stats.currentHP <= 0f) return;

        stateTimer += Time.deltaTime;

        if (stats.currentHP < stats.maxHP * 0.3f && currentState != State.Retreat) {
            ChangeState(State.Retreat);
        }

        if (currentState == State.Idle) {
            HandleIdle();
        } else if (currentState == State.Move) {
            HandleMove();
        } else if (currentState == State.Shoot) {
            HandleShoot();
        } else if (currentState == State.Retreat) {
            HandleRetreat();
        }
    }

    void ChangeState(State newState) {
        currentState = newState;
        stateTimer = 0f;
    }

    void HandleIdle() {
        if (stateTimer > 1f) {
            ChangeState(State.Move);
        }
    }

    void HandleMove() {
        transform.Translate(Vector3.down * stats.moveSpeed * Time.deltaTime);
        if (stateTimer > 2f) {
            ChangeState(State.Shoot);
        }
    }

    void HandleShoot() {
        if (stateTimer > 0.3f) {
            Fire();
            ChangeState(State.Idle);
        }
    }

    void HandleRetreat() {
        transform.Translate(Vector3.up * (stats.moveSpeed * 1.2f) * Time.deltaTime);
        if (transform.position.y > 6f) {
            gameObject.SetActive(false);
        }
    }

    void Fire() {
        if (bulletPrefab == null || firePoint == null) return;

        // GameObject bullet = ObjectPoolingManager.Instance.GetObject(bulletPrefab.name);
        // if (bullet != null) {
            // bullet.transform.position = firePoint.position;
            // bullet.transform.rotation = firePoint.rotation;
            // bullet.SetActive(true);

            // Bullet b = bullet.GetComponent<Bullet>();
            // if (b != null) {
                // b.SetDamage(stats.attack);
                // b.SetDirection(Vector3.down);
            // }
        // }
    }
}
