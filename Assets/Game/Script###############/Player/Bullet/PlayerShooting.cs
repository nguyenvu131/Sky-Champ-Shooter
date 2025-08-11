using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public static PlayerShooting Instance;
    private void OnEnable()
    {
        Instance = this;
    }
    private void OnDisable()
    {
        Instance = null;
    }
    public bool playerShoot = true;

    [Header("Fire Settings")]
    public Transform firePoint;
    public float fireRate = 0.3f;
    private float fireTimer = 0f;

    [Header("Bullet Settings")]
    [Range(1, 3)]
    public int bulletLevel = 1;
    public string bulletID_Level1 = "normal";
    public string bulletID_Level2 = "spread";
    public string bulletID_Level3 = "tri";

    private int originalBulletLevel;
    private Coroutine tempUpgradeRoutine;

    // Prefab fallback cho từng cấp độ
    private GameObject defaultBulletPrefab_Lv1;
    private GameObject defaultBulletPrefab_Lv2;
    private GameObject defaultBulletPrefab_Lv3;

    void Start()
    {
        if (firePoint == null)
            firePoint = transform.Find("FirePoint");

        // Load prefab fallback từ Resources
        defaultBulletPrefab_Lv1 = Resources.Load<GameObject>("Bullet/BulletPlayer");
        defaultBulletPrefab_Lv2 = Resources.Load<GameObject>("Bullet/BulletPlayer2");
        defaultBulletPrefab_Lv3 = Resources.Load<GameObject>("Bullet/BulletPlayer3");

        if (!defaultBulletPrefab_Lv1) Debug.LogWarning("Không tìm thấy Bullet/PlayerBullet01 trong Resources!");
        if (!defaultBulletPrefab_Lv2) Debug.LogWarning("Không tìm thấy Bullet/PlayerBullet02 trong Resources!");
        if (!defaultBulletPrefab_Lv3) Debug.LogWarning("Không tìm thấy Bullet/PlayerBullet03 trong Resources!");
    }
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerShoot = !playerShoot;
        }
#endif

        fireTimer += Time.deltaTime;
        if(playerShoot == false) return;
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
        SpawnBullet(bulletID_Level1, defaultBulletPrefab_Lv1, firePoint.position, firePoint.rotation, Vector2.up);
    }

    void FireLevel2()
    {
        float angleOffset = 15f;
        Quaternion leftRot = Quaternion.Euler(0, 0, angleOffset);
        Quaternion rightRot = Quaternion.Euler(0, 0, -angleOffset);

        SpawnBullet(bulletID_Level2, defaultBulletPrefab_Lv2, firePoint.position, leftRot, leftRot * Vector2.up);
        SpawnBullet(bulletID_Level2, defaultBulletPrefab_Lv2, firePoint.position, rightRot, rightRot * Vector2.up);
    }

    void FireLevel3()
    {
        float angleOffset = 15f;
        Quaternion leftRot = Quaternion.Euler(0, 0, angleOffset);
        Quaternion rightRot = Quaternion.Euler(0, 0, -angleOffset);

        SpawnBullet(bulletID_Level3, defaultBulletPrefab_Lv3, firePoint.position, firePoint.rotation, Vector2.up);
        SpawnBullet(bulletID_Level3, defaultBulletPrefab_Lv3, firePoint.position, leftRot, leftRot * Vector2.up);
        SpawnBullet(bulletID_Level3, defaultBulletPrefab_Lv3, firePoint.position, rightRot, rightRot * Vector2.up);
    }

    /// <summary>
    /// Spawn bullet từ pool hoặc prefab fallback
    /// </summary>
    void SpawnBullet(string bulletID, GameObject fallbackPrefab, Vector3 position, Quaternion rotation, Vector2 direction)
    {
        GameObject bullet = null;

        // Ưu tiên dùng Pool
        if (PlayerBulletPoolManager.Instance != null)
        {
            bullet = PlayerBulletPoolManager.Instance.SpawnBullet(bulletID, position, rotation);
        }

        // Nếu không có trong pool thì spawn từ prefab fallback
        if (bullet == null && fallbackPrefab != null)
        {
            bullet = Instantiate(fallbackPrefab, position, rotation);
        }

        if (bullet != null)
        {
            Bullet bulletComp = bullet.GetComponent<Bullet>();
            if (bulletComp != null)
                bulletComp.SetDirection(direction);
        }
    }

    /// <summary>
    /// Nâng cấp đạn tạm thời
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
        bulletLevel = Mathf.Max(bulletLevel, newLevel);

        Debug.Log("Tạm thời nâng đạn lên Level " + bulletLevel);

        yield return new WaitForSeconds(duration);

        bulletLevel = originalBulletLevel;
        Debug.Log("Đạn trở lại Level " + bulletLevel);
        tempUpgradeRoutine = null;
    }
}

