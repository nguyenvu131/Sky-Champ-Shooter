using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Pooing:
//🔫 Đạn / Projectile	BulletPool – nhỏ gọn, spawn/disable nhanh
//👾 Enemy / AI	EnemyPool – hỗ trợ spawn theo wave
//💥 Skill Effect / VFX	ParticlePool – tự tắt sau X giây
//🪙 Item Drop / Loot	ItemDropPool – spawn vàng, vật phẩm
//📦 UI Pooling	UIElementPool – cho popup, bảng chọn, tooltip
//🧱 Platform / Map Tile	PlatformPool – trong endless runner, dungeon random
//️ Combat Combo	SkillComboPool – dùng cho nhiều phase của skill
//📊 Popup Text (Damage / Heal)	DamageTextPool – floating text

//Nhiều đạn bắn ra liên tục (player và enemy)
//
//Nhiều explosion / particle
//
//Nhiều enemy / boss / mini boss
//
//Nhiều item drop (máu, shield, coin, buff...)
//
//Nhiều skill / laser / beam
//
//Nhiều UI tạm thời (damage popup, shield indicator...)

//GameObject bullet = ObjectPooler.Instance.SpawnFromPool("Bullet", shootPoint.position, shootPoint.rotation);

public class ObjectPooler : MonoBehaviour {

	public static ObjectPooler Instance;

	[System.Serializable]
	public class Pool
	{
		public string tag;
		public GameObject prefab;
		public int size = 10;
	}

	public List<Pool> pools;
	public Dictionary<string, Queue<GameObject>> poolDictionary;

	void Awake()
	{
		if (Instance == null)
			Instance = this;
	}

	void Start()
	{
		poolDictionary = new Dictionary<string, Queue<GameObject>>();

		foreach (Pool pool in pools)
		{
			Queue<GameObject> objectPool = new Queue<GameObject>();
			for (int i = 0; i < pool.size; i++)
			{
				GameObject obj = Instantiate(pool.prefab);
				obj.SetActive(false);
				objectPool.Enqueue(obj);
			}
			poolDictionary.Add(pool.tag, objectPool);
		}
	}

	public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
	{
		if (!poolDictionary.ContainsKey(tag))
		{
			Debug.LogWarning("Pool with tag " + tag + " not found!");
			return null;
		}

		GameObject obj = poolDictionary[tag].Dequeue();

		obj.SetActive(true);
		obj.transform.position = position;
		obj.transform.rotation = rotation;

		poolDictionary[tag].Enqueue(obj);

		return obj;
	}

	public GameObject Spawn(string key, Vector3 pos, Quaternion rot)
	{
		if (!poolDictionary.ContainsKey(key) || poolDictionary[key].Count == 0)
		{
			Debug.LogWarning("Pool not found or empty: " + key);
			return null;
		}

		GameObject obj = poolDictionary[key].Dequeue();
		obj.transform.position = pos;
		obj.transform.rotation = rot;
		obj.SetActive(true);
		return obj;
	}

	public void ReturnToPool(string key, GameObject obj)
	{
		obj.SetActive(false);
		if (!poolDictionary.ContainsKey(key))
			poolDictionary[key] = new Queue<GameObject>();

		poolDictionary[key].Enqueue(obj);
	}

	public void CreatePool(string key, GameObject prefab, int size)
	{
		if (!poolDictionary.ContainsKey(key))
			poolDictionary[key] = new Queue<GameObject>();

		for (int i = 0; i < size; i++)
		{
			GameObject obj = Instantiate(prefab);
			obj.SetActive(false);
			poolDictionary[key].Enqueue(obj);
		}
	}
}
