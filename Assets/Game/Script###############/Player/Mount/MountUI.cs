using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MountUI : MonoBehaviour
{
    [Header("Mount UI Elements")]
    public Image mountIcon;
    public Text mountNameText;
    public Text mountStatsText;
    public Button equipButton;
    public Button skillButton;
    public GameObject tooltipPanel;
    public Text tooltipText;

    private MountData currentMountData;
    private MountManager mountManager;

    void Start()
    {
        mountManager = FindObjectOfType<MountManager>();
        tooltipPanel.SetActive(false);

        equipButton.onClick.AddListener(OnEquipMount);
        skillButton.onClick.AddListener(OnUseSkill);
    }

    public void SetMountData(MountData data)
    {
        currentMountData = data;

        if (mountIcon != null)
            mountIcon.sprite = data.icon;

        if (mountNameText != null)
            mountNameText.text = data.mountName;

        if (mountStatsText != null)
        {
            mountStatsText.text =
                string.Format("HP+{0}  ATK+{1}  DEF+{2}  SPD+{3}",
                data.bonusHP, data.bonusAttack, data.bonusDefense, data.bonusSpeed);
        }

        if (tooltipText != null)
        {
            tooltipText.text = string.Format(
                "<b>{0}</b>\nType: {1}  Rarity: {2}\nSkill: {3}",
                data.mountName, data.type, data.rarity,
                data.mountSkill != null ? data.mountSkill.skillName : "None"
            );
        }
    }

    public void OnEquipMount()
    {
        if (mountManager != null && currentMountData != null)
        {
            mountManager.EquipMount(currentMountData);
            Debug.Log("Equipped mount: " + currentMountData.mountName);
        }
    }

    public void OnUseSkill()
    {
        if (mountManager != null)
        {
            mountManager.TriggerMountSkill();
        }
    }

    public void ShowTooltip()
    {
        tooltipPanel.SetActive(true);
    }

    public void HideTooltip()
    {
        tooltipPanel.SetActive(false);
    }
}
