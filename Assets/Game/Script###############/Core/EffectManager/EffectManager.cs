using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Khi bắn trúng quái
// EffectManager.Instance.PlayEffect("Hit_Lv1", hitPosition);

// Khi quái chết
// EffectManager.Instance.PlayEffect("Explosion_Lv1", transform.position);

// Khi player dùng boost
// EffectManager.Instance.PlayEffect("Trail_Lv2", player.transform.position, player.transform);

public class EffectManager : Singleton<EffectManager> 
{

	// public static EffectManager Instance;

    // private Dictionary<string, EffectData> effectDict = new Dictionary<string, EffectData>();

    // void Awake() 
	// {
        // if (Instance == null) Instance = this;
        // else Destroy(gameObject);

        
    // }
	
	// void Start()
	// {
		// LoadAllEffects();
	// }

    // void LoadAllEffects() {
        // EffectData[] allEffects = Resources.LoadAll<EffectData>("Effects");

        // foreach (EffectData effect in allEffects) {
            // if (!effectDict.ContainsKey(effect.effectID)) {
                // effectDict.Add(effect.effectID, effect);
            // }
        // }
    // }

    // public void PlayEffect(string effectID, Vector3 pos, Transform parent = null) {
        // if (effectDict.ContainsKey(effectID)) {
            // EffectData effect = effectDict[effectID];

            // GameObject fx = Instantiate(effect.prefab, pos, Quaternion.identity);
            // if (parent != null) fx.transform.SetParent(parent);

            // if (effect.sfx != null)
                // AudioSource.PlayClipAtPoint(effect.sfx, pos);

            // Destroy(fx, effect.duration);
        // } else {
            // Debug.LogWarning("Effect ID not found: " + effectID);
        // }
    // }
	
	
		[System.Serializable]
		public class EffectEntry
		{
			public string effectName;
			public GameObject prefab;
			public int preloadCount = 5;
		}

		public List<EffectEntry> effectEntries = new List<EffectEntry>();

		private Dictionary<string, Queue<GameObject>> poolDict = new Dictionary<string, Queue<GameObject>>();
		private Dictionary<string, GameObject> prefabDict = new Dictionary<string, GameObject>();

		protected override void Awake()
		{
			base.Awake();
			InitPools();
		}

		private void InitPools()
		{
			foreach (var entry in effectEntries)
			{
				if (!prefabDict.ContainsKey(entry.effectName))
				{
					prefabDict.Add(entry.effectName, entry.prefab);
					poolDict.Add(entry.effectName, new Queue<GameObject>());

					for (int i = 0; i < entry.preloadCount; i++)
					{
						GameObject obj = Instantiate(entry.prefab);
						obj.SetActive(false);
						poolDict[entry.effectName].Enqueue(obj);
					}
				}
			}
		}

		public GameObject SpawnEffect(string effectName, Vector3 position, Quaternion rotation, float autoDisableTime = 1.5f)
		{
			if (!poolDict.ContainsKey(effectName)) return null;

			GameObject obj = (poolDict[effectName].Count > 0) ?
				poolDict[effectName].Dequeue() :
				Instantiate(prefabDict[effectName]);

			obj.transform.position = position;
			obj.transform.rotation = rotation;
			obj.SetActive(true);

			StartCoroutine(DisableAfterTime(effectName, obj, autoDisableTime));
			return obj;
		}

		public GameObject SpawnEffect(string effectName, Vector3 position)
		{
			return SpawnEffect(effectName, position, Quaternion.identity);
		}

		private System.Collections.IEnumerator DisableAfterTime(string name, GameObject obj, float time)
		{
			yield return new WaitForSeconds(time);
			obj.SetActive(false);
			poolDict[name].Enqueue(obj);
		}
	
}
