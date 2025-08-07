using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShootPatternType
{
    Single,         // 1 viên thẳng
    Spread3,        // 3 viên tỏa
    Circle8,        // 8 viên toàn hướng
    Fan5,           // 5 viên hình quạt
    TargetPlayer3   // 3 viên hướng về player + lệch trái/phải
}

public class MonsterShooter3 : MonoBehaviour {

	public GameObject bulletPrefab;
    public float shootInterval = 2f;
    public float bulletSpeed = 4f;
    public ShootPatternType shootPattern;

    private float timer = 0f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= shootInterval)
        {
            FirePattern();
            timer = 0f;
        }
    }

    void FirePattern()
    {
        switch (shootPattern)
        {
            case ShootPatternType.Single:
                Shoot(Vector2.down);
                break;

            case ShootPatternType.Spread3:
                ShootDir(-15);
                ShootDir(0);
                ShootDir(15);
                break;

            case ShootPatternType.Fan5:
                for (int i = -2; i <= 2; i++)
                {
                    ShootDir(i * 10); // -20, -10, 0, 10, 20
                }
                break;

            case ShootPatternType.Circle8:
                for (int i = 0; i < 8; i++)
                {
                    float angle = i * 360f / 8f;
                    Vector2 dir = Quaternion.Euler(0, 0, angle) * Vector2.down;
                    Shoot(dir);
                }
                break;

            case ShootPatternType.TargetPlayer3:
                Vector2 toPlayer = (player.position - transform.position).normalized;
                Vector2 dirL = Quaternion.Euler(0, 0, -10) * toPlayer;
                Vector2 dirC = toPlayer;
                Vector2 dirR = Quaternion.Euler(0, 0, 10) * toPlayer;
                Shoot(dirL);
                Shoot(dirC);
                Shoot(dirR);
                break;
        }
    }

    void Shoot(Vector2 direction)
    {
        GameObject b = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        b.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
    }

    void ShootDir(float angle)
    {
        Vector2 dir = Quaternion.Euler(0, 0, angle) * Vector2.down;
        Shoot(dir);
    }
}
