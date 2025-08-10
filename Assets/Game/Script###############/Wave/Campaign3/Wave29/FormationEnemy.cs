using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationEnemy : MonoBehaviour {

	public float moveSpeed = 2f;
    public float waitTimeAtEnd = 1f;
    public float distanceToTravel = 3f;
    public float shootInterval = 2f;
    public GameObject bulletPrefab;

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingToTarget = true;
    private float shootTimer;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + Vector3.down * distanceToTravel;
        shootTimer = shootInterval;
    }

    void Update()
    {
        // Bắn định kỳ
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            Shoot();
            shootTimer = shootInterval;
        }

        // Di chuyển tới target và quay lại
        float step = moveSpeed * Time.deltaTime;
        if (movingToTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
            if (Vector3.Distance(transform.position, targetPos) < 0.01f)
                StartCoroutine(WaitAndReturn());
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
            if (Vector3.Distance(transform.position, startPos) < 0.01f)
                StartCoroutine(WaitAndForward());
        }
    }

    IEnumerator WaitAndReturn()
    {
        yield return new WaitForSeconds(waitTimeAtEnd);
        movingToTarget = false;
    }

    IEnumerator WaitAndForward()
    {
        yield return new WaitForSeconds(waitTimeAtEnd);
        movingToTarget = true;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<EnemyBullet29>().Init(Vector3.down);
    }
}
