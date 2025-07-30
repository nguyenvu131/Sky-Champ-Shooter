using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletLevelData
{
    public GameObject bulletPrefab;
    public float damage;
    public float speed;
    public int bulletCount; // Số lượng đạn bắn ra
    public float spreadAngle; // Góc lệch giữa các viên đạn
}
