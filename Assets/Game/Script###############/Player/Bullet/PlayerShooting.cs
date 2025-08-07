using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;

    public float fireRate = 0.3f;
    private float fireTimer = 0f;

    [Range(1, 3)]
    public int bulletLevel = 1;

    // Tương ứng ID trong BulletPoolManager
    public string bulletID_Level1 = "normal";
    public string bulletID_Level2 = "spread";
    public string bulletID_Level3 = "tri";
	
	private int originalBulletLevel;
	private Coroutine tempUpgradeRoutine;

    void Start()
    {
        if (firePoint == null)
            firePoint = transform.Find("FirePoint");
    }

    void FixedUpdate()
    {
        fireTimer += Time.fixedDeltaTime;

        if (fireTimer >= fireRate)
        {
            fireTimer = 0f;
            Fire();
        }
    }

    void Fire()
    {
        switch (bulletLevel)
        {
            case 1: FireLevel1(); break;
            case 2: FireLevel2(); break;
            case 3: FireLevel3(); break;
        }
    }

    void FireLevel1()
    {
        GameObject bullet = PlayerBulletPoolManager.Instance.SpawnBullet(bulletID_Level1, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().SetDirection(Vector2.up);
    }

    void FireLevel2()
    {
        float angleOffset = 15f;
        Quaternion leftRot = Quaternion.Euler(0, 0, angleOffset);
        Quaternion rightRot = Quaternion.Euler(0, 0, -angleOffset);

        GameObject bullet1 = PlayerBulletPoolManager.Instance.SpawnBullet(bulletID_Level2, firePoint.position, leftRot);
        bullet1.GetComponent<Bullet>().SetDirection(leftRot * Vector2.up);

        GameObject bullet2 = PlayerBulletPoolManager.Instance.SpawnBullet(bulletID_Level2, firePoint.position, rightRot);
        bullet2.GetComponent<Bullet>().SetDirection(rightRot * Vector2.up);
    }

    void FireLevel3()
    {
        float angleOffset = 15f;

        GameObject center = PlayerBulletPoolManager.Instance.SpawnBullet(bulletID_Level3, firePoint.position, firePoint.rotation);
        center.GetComponent<Bullet>().SetDirection(Vector2.up);

        Quaternion leftRot = Quaternion.Euler(0, 0, angleOffset);
        Quaternion rightRot = Quaternion.Euler(0, 0, -angleOffset);

        GameObject left = PlayerBulletPoolManager.Instance.SpawnBullet(bulletID_Level3, firePoint.position, leftRot);
        left.GetComponent<Bullet>().SetDirection(leftRot * Vector2.up);

        GameObject right = PlayerBulletPoolManager.Instance.SpawnBullet(bulletID_Level3, firePoint.position, rightRot);
        right.GetComponent<Bullet>().SetDirection(rightRot * Vector2.up);
    }
	
	/// <summary>
	/// Gọi để nâng cấp đạn tạm thời trong X giây
	/// </summary>
	public void TemporaryUpgradeBullet(int newLevel, float duration)
	{
		if (tempUpgradeRoutine != null)
			StopCoroutine(tempUpgradeRoutine);

		tempUpgradeRoutine = StartCoroutine(TempUpgradeRoutine(newLevel, duration));
	}

	private IEnumerator TempUpgradeRoutine(int newLevel, float duration)
	{
		originalBulletLevel = bulletLevel;

		// Đảm bảo không giảm level nếu đang cao hơn buff
		bulletLevel = Mathf.Max(bulletLevel, newLevel);
		Debug.Log("Tạm thời nâng đạn lên Level " + bulletLevel);

		yield return new WaitForSeconds(duration);

		bulletLevel = originalBulletLevel;
		Debug.Log("Đạn trở lại Level " + bulletLevel);
		tempUpgradeRoutine = null;
	}
}

