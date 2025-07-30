using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour {

	public Slider hpSlider;
	public Text levelText;

	public PlayerStats stats;

	void Update() {
		hpSlider.value = (float)stats.currentHP / stats.maxHP;
		levelText.text = "Lv " + stats.level.ToString();
	}
}
