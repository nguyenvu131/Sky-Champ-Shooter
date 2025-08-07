using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupDamageSpawner : MonoBehaviour
{
    public GameObject popupPrefab;

    public void ShowDamage(int damage, Transform monsterTransform)
    {
        if (popupPrefab == null)
        {
            popupPrefab = Resources.Load<GameObject>("Popup/PopupDamageText"); // đảm bảo đường dẫn đúng trong Resources
            if (popupPrefab == null)
            {
                Debug.LogError("Không tìm thấy prefab PopupDamageText trong thư mục Resources/Popup/");
                return;
            }
        }

        // Tìm Canvas
        // Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        // if (canvas == null)
        // {
            // Debug.LogError("Không tìm thấy Canvas trong scene!");
            // return;
        // }

        Vector3 worldPosition = monsterTransform.position + new Vector3(-0.5f, 1.5f, 0); // lệch lên trên đầu quái
		// Với canvas overlay: chuyển worldPos sang screenPos
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPosition);
        GameObject popup = Instantiate(popupPrefab, transform);
        popup.transform.position = screenPos;
        popup.GetComponent<PopupDamage>().SetDamage(damage, Color.red);
      
    }
	
}
