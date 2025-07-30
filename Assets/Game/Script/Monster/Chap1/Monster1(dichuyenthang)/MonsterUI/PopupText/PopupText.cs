using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Damage thường
//PopupText.Show("-120", transform.position, PopupType.Damage);

public enum PopupType
{
	Damage,
	Critical,
	Heal,
	Block
}

public class PopupText : MonoBehaviour {

	public Text textMesh; // hoặc TMPro.TextMeshProUGUI nếu dùng TMP
	public Color damageColor = Color.red;
	public Color critColor = new Color(1f, 0.6f, 0f);
	public Color healColor = Color.green;
	public Color blockColor = Color.gray;

	public Animator animator;

	public void Setup(string value, PopupType type)
	{
		textMesh.text = value;

		switch (type)
		{
		case PopupType.Damage:
			textMesh.color = damageColor;
			break;
		case PopupType.Critical:
			textMesh.color = critColor;
			textMesh.fontSize = 48;
			break;
		case PopupType.Heal:
			textMesh.color = healColor;
			break;
		case PopupType.Block:
			textMesh.color = blockColor;
			break;
		}

		if (animator != null)
			animator.SetTrigger("Pop");
	}

//	public static void Create(string value, Vector3 worldPos, PopupType type)
//	{
//		GameObject prefab = Resources.Load<GameObject>("PopupText"); // Đặt vào folder Resources
//		if (prefab == null) return;
//
//		GameObject instance = Instantiate(prefab, worldPos, Quaternion.identity);
//		instance.GetComponent<PopupText>().Setup(value, type);
//	}

	public void ReturnToPool()
	{
		PopupTextPool.Instance.ReturnToPool(this);
	}

	public static void Show(string value, Vector3 worldPos, PopupType type)
	{
		PopupText popup = PopupTextPool.Instance.GetPopup();
		popup.transform.position = worldPos + Random.insideUnitSphere * 0.3f;
		popup.Setup(value, type);
	}
}
