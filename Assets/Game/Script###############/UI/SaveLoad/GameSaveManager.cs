using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameSaveManager : MonoBehaviour {

	public static string playerFile = "player.es3";

    // Save Player
    public static void SavePlayer(PlayerData data)
    {
        ES3.Save("player", data, playerFile);
    }

    // Load Player
    public static PlayerData LoadPlayer()
    {
        if (ES3.FileExists(playerFile) && ES3.KeyExists("player", playerFile))
            return ES3.Load<PlayerData>("player", playerFile);
        else
            return new PlayerData(); // Trả về dữ liệu mặc định nếu chưa có
    }

    // Xóa file lưu
    public static void DeleteSave()
    {
        ES3.DeleteFile(playerFile);
        Debug.Log("Player save file deleted.");
    }

    // Debug nội dung file
    public static void LogSaveFile()
    {
        string path = Application.persistentDataPath + "/" + playerFile;
        if (File.Exists(path))
            Debug.Log(File.ReadAllText(path));
        else
            Debug.LogWarning("Save file not found: " + path);
    }
}
