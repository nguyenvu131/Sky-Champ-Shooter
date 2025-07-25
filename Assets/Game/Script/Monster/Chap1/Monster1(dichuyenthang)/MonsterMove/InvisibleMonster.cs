using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Invisible Monster – Tàng hình khi không tấn công
public class InvisibleMonster : MonoBehaviour {

	private SpriteRenderer sr;
	private float visibleTime = 1.5f;
	private float invisibleTime = 2f;
	private float timer;
	private bool isVisible = true;

	void OnEnable()
	{
		sr = GetComponent<SpriteRenderer>();
		timer = 0f;
	}

	void Update()
	{
		timer += Time.deltaTime;

		if (isVisible && timer >= visibleTime)
		{
			Hide();
		}
		else if (!isVisible && timer >= invisibleTime)
		{
			Show();
		}
	}

	void Hide()
	{
		sr.enabled = false;
		isVisible = false;
		timer = 0f;
	}

	void Show()
	{
		sr.enabled = true;
		isVisible = true;
		timer = 0f;
	}
}
