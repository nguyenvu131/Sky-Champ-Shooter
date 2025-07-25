using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	public int maxHealth = 100;
	private int currentHealth;

	public GameObject healthBarCanvas;
	public Image fillImage;

	public float showDuration = 2f;
	private Coroutine hideCoroutine;

	void Start()
	{
		currentHealth = maxHealth;
		healthBarCanvas.SetActive(false); // Ẩn ban đầu
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

		UpdateHealthBar();

		if (currentHealth <= 0)
			Die();
	}

	void UpdateHealthBar()
	{
		float percent = (float)currentHealth / maxHealth;
		fillImage.fillAmount = percent;

		healthBarCanvas.SetActive(true);

		if (hideCoroutine != null)
			StopCoroutine(hideCoroutine);
		hideCoroutine = StartCoroutine(HideBarAfterDelay());
	}

	IEnumerator HideBarAfterDelay()
	{
		yield return new WaitForSeconds(showDuration);
		healthBarCanvas.SetActive(false);
	}

	void Die()
	{
		// Hiệu ứng chết, drop item, v.v.
		Destroy(gameObject);
	}
}
