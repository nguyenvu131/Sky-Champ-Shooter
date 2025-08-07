using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBug : MonoBehaviour {

	public int hp = 20;

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            Destroy(gameObject); // Vỡ khi bị tiêu diệt
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            // Chặn đạn
            TakeDamage(10);
            Destroy(other.gameObject); // Xóa đạn
        }
    }
}
