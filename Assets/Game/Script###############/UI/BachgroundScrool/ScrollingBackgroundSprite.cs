using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackgroundSprite : MonoBehaviour
{
    public float scrollSpeed = 2f;   // Tốc độ cuộn
    public Transform[] backgrounds;  // BG1, BG2, BG3, BG4, BG5, BG6...
    private float spriteHeight;
    private bool stopScrolling = false; // Cờ dừng cuộn

    void Start()
    {

		for (int i = 0; i < backgrounds.Length; i++)
		{
			backgrounds[i].Translate(Vector3.down * scrollSpeed * Time.deltaTime);
		}
		
        if (backgrounds.Length == 0)
        {
            Debug.LogError("Chưa gán backgrounds!");
            return;
        }

        // Lấy chiều cao sprite (giả sử tất cả BG cùng kích thước)
        spriteHeight = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        if (stopScrolling) return; // Nếu đã dừng thì bỏ qua

        bool allGone = true; // Kiểm tra xem tất cả BG đã ra khỏi màn chưa

        for (int i = 0; i < backgrounds.Length; i++)
        {
            // Di chuyển xuống
            backgrounds[i].Translate(Vector3.down * scrollSpeed * Time.deltaTime);

            // Nếu BG còn trong màn thì allGone = false
            float cameraBottom = Camera.main.transform.position.y - Camera.main.orthographicSize;

			if (backgrounds[i].position.y + spriteHeight / 64 > cameraBottom)
			{
				allGone = false;
			}
        }

        // Nếu tất cả BG đã trượt ra khỏi màn hình thì dừng
        if (allGone)
        {
            stopScrolling = true;
        }
    }
}
