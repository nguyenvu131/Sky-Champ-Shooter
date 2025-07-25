using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public MonsterStats stats;
	
	public Image fillImage;
    public Image delayedImage;
    public Image iconImage;
    public Text nameText;
	
	  // 🆕 Các text mới:
    public Text levelText;
    public Text hpText;
    public Text mpText;

    public Text atkText;
    public Text defText;
    public Text agiText;
    public Text vitText;

    public float smoothSpeed = 5f;
    private float targetFill = 1f;

    private Transform target;
    private Vector3 offset = new Vector3(0, 1f, 0);

    public void SetTarget(Transform t)
    {
        target = t;
    }

    public void SetFill(float current, float max)
    {
        targetFill = Mathf.Clamp01(current / max);
    }
	
	public void SetMP(float current, float max)
    {
        if (mpText != null)
            mpText.text = "MP: " + Mathf.CeilToInt(current) + " / " + Mathf.CeilToInt(max);
    }
	
    public void SetInfo(string name, Sprite icon)
    {
        if (nameText != null)
            nameText.text = name;

        if (iconImage != null)
            iconImage.sprite = icon;
		
		if (levelText != null)
            levelText.text = "Lv. " + stats.level;
    }
	
	public void SetStats(int atk, int def, int agi, int vit)
    {
        if (atkText != null) atkText.text = "ATK: " + atk;
        if (defText != null) defText.text = "DEF: " + def;
        if (agiText != null) agiText.text = "AGI: " + agi;
        if (vitText != null) vitText.text = "VIT: " + vit;
    }
	
    void Update()
    {
        if (target != null)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position + offset);
            transform.position = screenPos;
        }

        if (fillImage != null)
            fillImage.fillAmount = Mathf.Lerp(fillImage.fillAmount, targetFill, Time.deltaTime * smoothSpeed);

        if (delayedImage != null)
        {
            if (delayedImage.fillAmount > fillImage.fillAmount)
                delayedImage.fillAmount = Mathf.Lerp(delayedImage.fillAmount, fillImage.fillAmount, Time.deltaTime * (smoothSpeed / 2f));
        }
		
		// HP fill
        if (fillImage != null)
            fillImage.fillAmount = Mathf.Lerp(fillImage.fillAmount, targetFill, Time.deltaTime * smoothSpeed);

        if (delayedImage != null && delayedImage.fillAmount > fillImage.fillAmount)
            delayedImage.fillAmount = Mathf.Lerp(delayedImage.fillAmount, fillImage.fillAmount, Time.deltaTime * (smoothSpeed / 2f));
    }

    public void Show(bool show)
    {
        gameObject.SetActive(show);
    }
}
