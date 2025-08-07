using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonUI2 : MonoBehaviour {

	public Image iconImage;
    public Text levelText;
    public Image cooldownFill;
    public Button button;

    private SkillData skillData;
    private float cooldownTimer;
    private bool isCoolingDown = false;

    public void Init(SkillData data)
    {
        skillData = data;
        iconImage.sprite = data.icon;
        levelText.text = "Lv" + data.level;
        cooldownFill.fillAmount = 0f;
        button.onClick.AddListener(OnSkillPressed);
    }

    void Update()
    {
        if (isCoolingDown)
        {
            cooldownTimer -= Time.deltaTime;
            cooldownFill.fillAmount = cooldownTimer / skillData.cooldown;

            if (cooldownTimer <= 0f)
            {
                isCoolingDown = false;
                cooldownFill.fillAmount = 0f;
            }
        }
    }

    void OnSkillPressed()
    {
        if (isCoolingDown) return;

        Debug.Log("Skill used: " + skillData.skillID);
        // TODO: Trigger skill effect here (e.g., SkillManager.CastSkill(skillData))

        // Start cooldown
        cooldownTimer = skillData.cooldown;
        isCoolingDown = true;
    }
}
