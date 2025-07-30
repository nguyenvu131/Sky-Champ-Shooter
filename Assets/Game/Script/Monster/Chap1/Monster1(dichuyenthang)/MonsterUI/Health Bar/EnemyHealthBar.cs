using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour {

	public Image fillImage;
	public CanvasGroup canvasGroup;
	public Vector3 offset = new Vector3(0, 2, 0); // vị trí trên đầu

	private Transform target;
	private float maxHealth;
	private float currentHealth;

	public void Setup(Transform followTarget, float maxHp)
	{
		target = followTarget;
		maxHealth = maxHp;
		currentHealth = maxHp;
		fillImage.fillAmount = 1f;
		canvasGroup.alpha = 0f;
	}

	public void UpdateHealth(float newHp)
	{
		currentHealth = newHp;
		fillImage.fillAmount = currentHealth / maxHealth;
		canvasGroup.alpha = 1f;

		CancelInvoke("Hide");
		Invoke("Hide", 3f); // ẩn sau 3 giây không bị đánh
	}

	void Hide()
	{
		canvasGroup.alpha = 0f;
	}

	void LateUpdate()
	{
		if (target != null)
		{
			transform.position = target.position + offset;
		}
	}
}
