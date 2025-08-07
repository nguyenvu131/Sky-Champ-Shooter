using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSaveLoad : MonoBehaviour 
{
	
	void Start()
    {
        // Tạo dữ liệu mới
        PlayerData data = ScriptableObject.CreateInstance<PlayerData>();
        data.playerName = "sky champ";
        data.level = 3;
        data.gold = 500;
        // data.position = new Vector3(1, 2, 3);

        // Lưu
        GameSaveManager.SavePlayer(data);
        // Debug.Log("Đã lưu dữ liệu ES3.");

        // Tải lại
        // PlayerData loaded = GameSaveManager.LoadPlayer();
        // Debug.Log("Người chơi: " + loaded.playerName + " | Level: " + loaded.level + " | Vàng: " + loaded.gold);
    }
}
