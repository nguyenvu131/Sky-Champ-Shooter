using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUpgradeItem : MonoBehaviour
{
    public int upgradeAmount = 1; // số level tăng (mặc định 1)

    void OnTriggerEnter2D(Collider2D other)
    {
        // Nếu chạm vào Player
        if (other.CompareTag("Player"))
        {
            PlayerShooting playerShooting = other.GetComponent<PlayerShooting>();
            if (playerShooting != null)
            {
                // Tăng cấp đạn, tối đa 3
                playerShooting.bulletLevel = Mathf.Min(playerShooting.bulletLevel + upgradeAmount, 3);
                Debug.Log("Bullet upgraded to Level " + playerShooting.bulletLevel);
            }

            // Tạo hiệu ứng/âm thanh tại đây nếu muốn
            // AudioSource.PlayClipAtPoint(upgradeSFX, transform.position);

            // Xóa item sau khi nhặt
            Destroy(gameObject);
        }
    }
}