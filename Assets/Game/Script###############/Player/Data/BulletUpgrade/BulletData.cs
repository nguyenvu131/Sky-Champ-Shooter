using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletData", menuName = "Weapon/Bullet Data")]
public class BulletData : ScriptableObject
{
    public List<BulletLevelData> levels;
}
