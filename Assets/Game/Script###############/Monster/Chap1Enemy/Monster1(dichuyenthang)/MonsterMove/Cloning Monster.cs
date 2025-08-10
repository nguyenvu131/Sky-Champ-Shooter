using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cloning Monster – Phân thân khi gần chết
public class CloningMonster : MonoBehaviour {

	public string cloneTag = "MiniMonster";
	public int cloneCount = 2;
	public float cloneOffset = 0.5f;

	private MonsterStats stats;
	private bool hasCloned = false;

	void OnEnable()
	{
		stats = GetComponent<MonsterStats>();
		hasCloned = false;
	}

	void Update()
	{
		if (!hasCloned && stats.currentHP < stats.maxHP * 0.3f)
		{
			Clone();
		}
	}

	void Clone()
	{
		hasCloned = true;

		for (int i = 0; i < cloneCount; i++)
		{
			Vector3 offset = new Vector3(Random.Range(-cloneOffset, cloneOffset), 0, 0);
			GameObject mini = ObjectPooler.Instance.Spawn(cloneTag, transform.position + offset, Quaternion.identity);
			mini.GetComponent<MonsterStats>().Init(stats.level);
		}
	}
}
