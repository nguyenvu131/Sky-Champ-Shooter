using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingBeast : MonoBehaviour {

	public float warningDuration = 1f;   // Thời gian cảnh báo
    public float chargeSpeed = 12f;      // Tốc độ lao cực nhanh
    public GameObject warningEffect;     // Prefab hiệu ứng warning (nếu có)

    private bool isCharging = false;
    private Vector3 chargeDirection = Vector3.left;

    void Start()
    {
        if (warningEffect != null)
        {
            Instantiate(warningEffect, transform.position, Quaternion.identity, transform);
        }

        Invoke("StartCharge", warningDuration);
    }

    void StartCharge()
    {
        isCharging = true;

        // Xoá warning effect nếu có
        Transform warning = transform.Find("ChargeWarning(Clone)");
        if (warning != null)
        {
            Destroy(warning.gameObject);
        }
    }

    void Update()
    {
        if (isCharging)
        {
            transform.Translate(chargeDirection * chargeSpeed * Time.deltaTime);
        }

        // Tự hủy nếu vượt khỏi màn hình
        if (transform.position.x < -12f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isCharging && other.CompareTag("Player"))
        {
            // Gây sát thương nếu có hệ thống PlayerHealth
            // other.GetComponent<PlayerHealth>()?.TakeDamage(30);

            Destroy(gameObject);
        }
    }
}
