using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrollManager : MonoBehaviour
{
	[System.Serializable]
	public class BackgroundLayer
	{
		public string name;
		public float scrollSpeed = 0.5f;
		public List<Transform> pieces;
	}

	public List<BackgroundLayer> layers;
	public float heightToReset = 20f;
	public bool isScrolling = true;

	public Transform targetToTrack; // Camera hoặc Player
	public float endY = -100f; // Tọa độ Y khi đạt đến điểm cuối map
	private bool hasReachedEnd = false;

	void Update()
	{
		if (isScrolling)
		{
			foreach (var layer in layers)
			{
				foreach (Transform piece in layer.pieces)
				{
					piece.Translate(Vector3.down * layer.scrollSpeed * Time.deltaTime);

					if (piece.position.y <= -heightToReset)
					{
						float highestY = GetHighestY(layer.pieces);
						piece.position = new Vector3(piece.position.x, highestY + heightToReset, piece.position.z);
					}
				}
			}

			CheckEndReached();
		}
	}

	float GetHighestY(List<Transform> pieces)
	{
		float highest = float.MinValue;
		foreach (Transform t in pieces)
			if (t.position.y > highest)
				highest = t.position.y;
		return highest;
	}

	void CheckEndReached()
	{
		if (hasReachedEnd || targetToTrack == null) return;

		if (targetToTrack.position.y <= endY)
		{
			hasReachedEnd = true;
			StopScrolling();

			Debug.Log(" Đã đến cuối map background!");

			// TODO: Gọi boss hoặc hiện panel chiến thắng ở đây
			// BossManager.Instance.SpawnBoss();
			// GameManager.Instance.OnStageEnd();
		}
	}

	public void StopScrolling()
	{
		isScrolling = false;
	}

	public void ResumeScrolling()
	{
		isScrolling = true;
		hasReachedEnd = false;
	}

	public void ChangeToBossBackground(Material bossMaterial)
	{
		foreach (var layer in layers)
		{
			foreach (Transform piece in layer.pieces)
			{
				var renderer = piece.GetComponent<SpriteRenderer>();
				if (renderer != null)
				{
					renderer.material = bossMaterial;
				}
			}
		}
	}
}
