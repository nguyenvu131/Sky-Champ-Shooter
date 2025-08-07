using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public GameObject shieldVisualPrefab;     // Prefab hiệu ứng lá chắn
    public float shieldDuration = 5f;         // Thời gian lá chắn tồn tại
    public float damageReductionPercent = 100f; // Giảm 100% sát thương nếu là khiên bất tử

    private GameObject currentShieldVisual;
    private bool isShieldActive = false;
    private float shieldTimer = 0f;

    void Update()
    {
        if (isShieldActive)
        {
            shieldTimer -= Time.deltaTime;
            if (shieldTimer <= 0f)
            {
                DeactivateShield();
            }
        }
    }

    public void ActivateShield()
    {
        if (isShieldActive) return;

        isShieldActive = true;
        shieldTimer = shieldDuration;

        // Hiển thị hiệu ứng
        if (shieldVisualPrefab != null)
        {
            currentShieldVisual = Instantiate(shieldVisualPrefab, transform.position, Quaternion.identity);
            currentShieldVisual.transform.SetParent(transform); // Gắn theo nhân vật
            currentShieldVisual.transform.localPosition = Vector3.zero;
        }

        Debug.Log("Shield activated!");
    }

    public void DeactivateShield()
    {
        isShieldActive = false;

        if (currentShieldVisual != null)
        {
            Destroy(currentShieldVisual);
        }

        Debug.Log("Shield deactivated!");
    }

    public float ModifyIncomingDamage(float incomingDamage)
    {
        if (isShieldActive)
        {
            float reducedDamage = incomingDamage * (1f - damageReductionPercent / 100f);
            return reducedDamage;
        }
        return incomingDamage;
    }

    public bool IsShieldActive()
    {
        return isShieldActive;
    }
}
