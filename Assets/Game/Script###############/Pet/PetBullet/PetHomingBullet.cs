using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetHomingBullet : Bullet {
    public float turnSpeed = 200f;
    private Transform target;

    void Update() {
        if (target == null) {
            target = FindClosestEnemy();
            if (target == null) return;
        }

        Vector3 dir = (target.position - transform.position).normalized;
        float rotateAmount = Vector3.Cross(dir, transform.up).z;
        transform.Rotate(0, 0, -rotateAmount * turnSpeed * Time.deltaTime);
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
    }

    Transform FindClosestEnemy() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float minDist = Mathf.Infinity;
        Transform closest = null;

        foreach (GameObject enemy in enemies) {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist < minDist) {
                minDist = dist;
                closest = enemy.transform;
            }
        }
        return closest;
    }
}
