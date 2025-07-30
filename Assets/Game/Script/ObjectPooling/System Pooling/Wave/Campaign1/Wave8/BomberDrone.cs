using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberDrone : MonoBehaviour {

	public float moveSpeed = 2f;
    public GameObject bombPrefab;
    public float dropInterval = 2f; // mỗi 2 giây thả bom

    private float dropTimer = 0f;

    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        dropTimer += Time.deltaTime;
        if (dropTimer >= dropInterval)
        {
            DropBomb();
            dropTimer = 0f;
        }

        // Tự hủy nếu bay khỏi màn hình bên trái
        if (transform.position.x < -12f)
        {
            Destroy(gameObject);
        }
    }

    void DropBomb()
    {
        if (bombPrefab != null)
        {
            Vector3 bombPos = transform.position + Vector3.down * 0.5f;
            Instantiate(bombPrefab, bombPos, Quaternion.identity);
        }
    }
}
