using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperEnemy : MonoBehaviour {

	public GameObject bulletPrefab;
    public LineRenderer laserLine;
    public float visionRange = 10f;
    public float shootCooldown = 3f;
    public float aimTime = 1f;
    public float bulletSpeed = 10f;

    private float shootTimer;
    private Transform player;
    private bool isAiming = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        shootTimer = shootCooldown;
        laserLine.enabled = false;
    }

    void Update()
    {
        shootTimer -= Time.deltaTime;

        if (player != null && shootTimer <= 0f && !isAiming)
        {
            Vector3 dir = (player.position - transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, visionRange);

            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                StartCoroutine(AimAndShoot(dir));
                shootTimer = shootCooldown;
            }
        }
    }

    IEnumerator AimAndShoot(Vector3 dir)
    {
        isAiming = true;
        laserLine.enabled = true;
        laserLine.SetPosition(0, transform.position);
        laserLine.SetPosition(1, transform.position + dir * visionRange);

        yield return new WaitForSeconds(aimTime);

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;

        laserLine.enabled = false;
        isAiming = false;
    }
}
