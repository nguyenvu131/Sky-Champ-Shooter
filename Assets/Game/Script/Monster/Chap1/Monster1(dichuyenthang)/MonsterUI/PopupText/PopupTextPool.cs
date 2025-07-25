using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupTextPool : MonoBehaviour {

	public static PopupTextPool Instance;
	public GameObject popupPrefab;
	public int initialPoolSize = 20;

	private Queue<PopupText> pool = new Queue<PopupText>();

	void Awake()
	{
		Instance = this;
		for (int i = 0; i < initialPoolSize; i++)
		{
			AddToPool();
		}
	}

	void AddToPool()
	{
		GameObject obj = Instantiate(popupPrefab, transform);
		obj.SetActive(false);
		pool.Enqueue(obj.GetComponent<PopupText>());
	}

	public PopupText GetPopup()
	{
		if (pool.Count == 0)
			AddToPool();

		var popup = pool.Dequeue();
		popup.gameObject.SetActive(true);
		return popup;
	}

	public void ReturnToPool(PopupText popup)
	{
		popup.gameObject.SetActive(false);
		pool.Enqueue(popup);
	}
}
