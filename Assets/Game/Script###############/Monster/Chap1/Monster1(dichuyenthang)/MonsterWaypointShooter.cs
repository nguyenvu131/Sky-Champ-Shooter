using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWaypointShooter : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform[] waypoints;
    public float moveSpeed = 5f;
    public float reachDistance = 0.5f;
    public float waitTimeAtWaypoint = 2f;

    [Header("Shooting")]
    public GameObject bulletPrefab;         // Prefab đạn
    public Transform firePoint;             // Vị trí bắn
    public int bulletsPerStop = 1;          // Số viên bắn mỗi lần dừng
    public float fireDelay = 0.2f;          // Delay giữa các viên (nếu >1 viên)

    private int currentWaypointIndex = 0;
    private bool isWaiting = false;

    void FixedUpdate()
    {
        if (waypoints.Length == 0 || rb == null || isWaiting) return;

        Transform targetPoint = waypoints[currentWaypointIndex];
        Vector3 direction = (targetPoint.position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;

        float distance = Vector3.Distance(transform.position, targetPoint.position);
        if (distance <= reachDistance)
        {
            StartCoroutine(WaitShootAndMoveNext());
        }
    }

    IEnumerator WaitShootAndMoveNext()
    {
        isWaiting = true;
        rb.velocity = Vector3.zero;

        // Bắn đạn
        for (int i = 0; i < bulletsPerStop; i++)
        {
            FireBullet();
            if (bulletsPerStop > 1)
                yield return new WaitForSeconds(fireDelay);
        }

        // Chờ thêm nếu cần sau khi bắn
        yield return new WaitForSeconds(waitTimeAtWaypoint);

        // Chuyển waypoint
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Length)
            currentWaypointIndex = 0;

        isWaiting = false;
    }

    void FireBullet()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
