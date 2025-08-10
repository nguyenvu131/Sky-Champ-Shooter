using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonManager : MonoBehaviour
{
    [System.Serializable]
    public class SkillSlot
    {
        public string skillID;
        public Button skillButton;
        public Image cooldownOverlay;
        public float cooldownTime;
        [HideInInspector] public float currentCooldown = 0f;
        [HideInInspector] public bool isOnCooldown = false;
    }

    public SkillSlot[] skillSlots;

    void Start()
    {
        foreach (SkillSlot slot in skillSlots)
        {
            string id = slot.skillID;
            slot.skillButton.onClick.AddListener(() => OnSkillButtonPressed(id));
        }
    }

    void Update()
    {
        foreach (SkillSlot slot in skillSlots)
        {
            if (slot.isOnCooldown)
            {
                slot.currentCooldown -= Time.deltaTime;

                if (slot.currentCooldown <= 0f)
                {
                    slot.isOnCooldown = false;
                    slot.cooldownOverlay.fillAmount = 0f;
                    slot.skillButton.interactable = true;
                }
                else
                {
                    float ratio = slot.currentCooldown / slot.cooldownTime;
                    slot.cooldownOverlay.fillAmount = ratio;
                    slot.skillButton.interactable = false;
                }
            }
        }
    }

    void OnSkillButtonPressed(string skillID)
    {
        SkillSlot slot = GetSkillSlotByID(skillID);
        if (slot == null || slot.isOnCooldown) return;

        Debug.Log("Skill Activated: " + skillID);

        ActivateSkill(skillID);
        StartCoroutine(StartCooldown(slot));
    }

    IEnumerator StartCooldown(SkillSlot slot)
    {
        slot.isOnCooldown = true;
        slot.currentCooldown = slot.cooldownTime;
        slot.cooldownOverlay.fillAmount = 1f;
        slot.skillButton.interactable = false;

        yield return null;
    }

    SkillSlot GetSkillSlotByID(string id)
    {
        foreach (SkillSlot slot in skillSlots)
        {
            if (slot.skillID == id)
                return slot;
        }
        return null;
    }

    void ActivateSkill(string skillID)
    {
        // Tùy game mà gọi đến SkillManager / PlayerSkillController
        switch (skillID)
        {
            case "FireNova":
                SkillManagerMonster.Instance.CastFireNova();
                break;
            case "Shield":
                SkillManagerMonster.Instance.ActivateShield();
                break;
            case "FreezeAll":
                SkillManagerMonster.Instance.FreezeEnemies();
                break;
            default:
                Debug.LogWarning("Skill not recognized: " + skillID);
                break;
        }
    }
}
