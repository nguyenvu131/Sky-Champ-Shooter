using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterUI : MonoBehaviour {

	public Text levelText;
	public Transform target; // quái

	void Update()
	{
		if (target != null)
		{
			Vector3 pos = Camera.main.WorldToScreenPoint(target.position + Vector3.up * 2f);
			transform.position = pos;
		}
	}

	public void SetLevel(int lv)
	{
		levelText.text = "Lv. " + lv;
	}
}
