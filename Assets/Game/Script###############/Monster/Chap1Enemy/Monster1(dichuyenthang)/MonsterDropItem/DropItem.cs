using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DropItem
{
	public string name;
	public GameObject prefab;
	[Range(0, 100)]
	public float dropRate; // Tỷ lệ %
	public int amount = 1; // Số lượng rơi
}
