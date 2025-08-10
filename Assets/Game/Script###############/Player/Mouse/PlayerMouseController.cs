using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float boundaryPadding = 0.5f;

    public bool autoFire = true;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.2f;
    private float fireCooldown = 0f;

    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        HandleShooting();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        Vector3 moveDirection = Vector3.zero;

        // Ưu tiên input từ bàn phím
        float horizontal = Input.GetAxisRaw("Horizontal"); // A/D hoặc ←/→
        float vertical = Input.GetAxisRaw("Vertical");     // W/S hoặc ↑/↓

        if (horizontal != 0 || vertical != 0)
        {
            moveDirection = new Vector3(horizontal, vertical, 0f).normalized;
            transform.position += moveDirection * moveSpeed * Time.fixedDeltaTime;
        }
        else
        {
            FollowMouse(); // Nếu không bấm phím thì follow chuột
        }

        ClampPosition(); // Luôn giới hạn trong màn hình
    }

    void FollowMouse()
    {
        if (mainCam == null) return;

        Vector3 mouseWorldPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        Vector3 targetPos = mouseWorldPos;

        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.fixedDeltaTime);
    }

    void ClampPosition()
    {
        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, -15f + boundaryPadding, 15f - boundaryPadding);
        clampedPos.y = Mathf.Clamp(clampedPos.y, -10.5f + boundaryPadding, 10.5f - boundaryPadding);
        transform.position = clampedPos;
    }

    void HandleShooting()
    {
        fireCooldown -= Time.deltaTime;

        if ((autoFire || Input.GetMouseButton(0)) && fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }
    }
}