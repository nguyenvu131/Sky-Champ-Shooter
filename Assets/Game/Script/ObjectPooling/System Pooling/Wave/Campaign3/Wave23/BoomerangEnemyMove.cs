using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangEnemyMove : MonoBehaviour {

	public float horizontalSpeed = 3f;
    public float verticalSpeed = 1.5f;
    public float arcHeight = 1.5f;
    public float turnTime = 1.5f;
    public int direction = 1; // 1 = từ trái → phải, -1 = từ phải → trái

    private float timer = 0f;
    private bool returning = false;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
		
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (!returning)
        {
            // Di chuyển hình vòng cung ban đầu
            float x = direction * horizontalSpeed * timer;
            float y = -verticalSpeed * timer + Mathf.Sin(timer * Mathf.PI / turnTime) * arcHeight;

            transform.position = startPos + new Vector3(x, y, 0);

            if (timer >= turnTime)
            {
                // Chuyển sang phase quay về
                returning = true;
                timer = 0f;
                startPos = transform.position;
            }
        }
        else
        {
            // Quay về theo đường thẳng
            transform.position += Vector3.down * verticalSpeed * Time.deltaTime;
        }
		
		if (Time.frameCount % 30 == 0) // cứ khoảng 0.5s bắn 1 lần
		{
			ShootBullet();
		}
    }
	
	void ShootBullet()
	{
		// Triển khai hàm này theo hệ thống bullet của bạn
		// Ví dụ: BulletManager.Instance.Spawn("EnemyBullet", transform.position, Vector2.down);
	}
}
