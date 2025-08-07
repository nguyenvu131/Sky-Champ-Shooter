using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour 
{
	// Singleton instance
    public static Game Instance { get; private set; }
	
	void Awake()
    {
        // Nếu đã có instance khác, hủy GameObject hiện tại
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Gán instance và đánh dấu không bị phá huỷ khi load scene
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Khởi tạo các giá trị nếu cần
        InitializeGame();
    }

    private void InitializeGame()
    {
        // Khởi tạo game logic, level, sound, v.v.
		
    }
}
