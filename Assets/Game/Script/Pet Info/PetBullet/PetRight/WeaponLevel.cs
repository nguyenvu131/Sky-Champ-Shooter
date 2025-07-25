using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapon/Weapon Data")]
public class WeaponLevel : ScriptableObject
{
    public string weaponID;
    public GameObject[] bulletPrefabs; // Mỗi prefab ứng với 1 cấp độ
    public float[] fireRates;          // Tốc độ bắn theo cấp độ
    public float[] damages;            // Sát thương theo cấp độ
}
