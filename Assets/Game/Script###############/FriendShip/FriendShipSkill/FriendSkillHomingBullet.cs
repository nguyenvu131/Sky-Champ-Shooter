using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendSkillHomingBullet : MonoBehaviour {

	public float speed = 8f;
    public float rotateSpeed = 200f;
    private Transform target;

    void Start()
    {
        target = FindClosestEnemy();
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 direction = (Vector2)target.position - (Vector2)transform.position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        GetComponent<Rigidbody2D>().angularVelocity = -rotateAmount * rotateSpeed;
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }

    Transform FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Monster");
        float minDist = Mathf.Infinity;
        Transform closest = null;
        foreach (var e in enemies)
        {
            float dist = Vector2.Distance(transform.position, e.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = e.transform;
            }
        }
        return closest;
    }
}
