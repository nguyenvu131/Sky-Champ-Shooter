using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFreezeController : MonoBehaviour
{
    private bool isFrozen = false;
    private float freezeTimer = 0f;

    private MonsterWaypointShooter movement; // hoặc AI component của bạn

    void Start()
    {
        movement = GetComponent<MonsterWaypointShooter>(); // Đổi thành script di chuyển của bạn
    }

    void Update()
    {
        if (isFrozen)
        {
            freezeTimer -= Time.deltaTime;
            if (freezeTimer <= 0f)
            {
                Unfreeze();
            }
        }
    }

    public void Freeze(float duration)
    {
        isFrozen = true;
        freezeTimer = duration;
        if (movement != null)
            movement.enabled = false; // Hoặc gọi Stop()

        // Thêm hiệu ứng đông băng ở đây nếu muốn
    }

    private void Unfreeze()
    {
        isFrozen = false;
        if (movement != null)
            movement.enabled = true;

        // Tắt hiệu ứng đông băng nếu có
    }
}
