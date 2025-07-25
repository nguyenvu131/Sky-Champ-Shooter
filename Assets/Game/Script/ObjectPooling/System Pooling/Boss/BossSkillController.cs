using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkillController : MonoBehaviour
{
    public void CastFireball()
    {
        BossSkillPoolManager.Instance.GetSkill(
            BossSkillType.Fireball, 
            transform.position + transform.forward * 2, 
            transform.rotation);
    }

    public void CastLightning()
    {
        BossSkillPoolManager.Instance.GetSkill(
            BossSkillType.LightningStrike,
            transform.position,
            Quaternion.identity);
    }
}
