using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossSkillType
{
    Fireball,
    LightningStrike,
    // Thêm skill khác tại đây
}

public interface IBossSkill
{
    void Activate(Vector3 position, Quaternion rotation);
    void Deactivate();
    GameObject GetGameObject();
}
