using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Quản lý tất cả hiệu ứng trong game.
/// Kết hợp với GameManager, WaveManagerMonster để trigger hiệu ứng.
/// </summary>
public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance;

    [System.Serializable]
    public class EffectInfo
    {
        public string effectName; // Tên hiệu ứng
        public GameObject effectPrefab; // Prefab hiệu ứng
        public float defaultDuration = 2f; // Thời gian tồn tại mặc định
    }

    [Header("Effect Settings")]
    public List<EffectInfo> effects = new List<EffectInfo>();
    public Transform effectParent; // Nơi chứa các hiệu ứng trong hierarchy

    private Dictionary<string, GameObject> effectDictionary = new Dictionary<string, GameObject>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        // DontDestroyOnLoad(gameObject);
        InitializeEffects();
    }

    /// <summary>
    /// Tạo dictionary để tìm hiệu ứng nhanh hơn
    /// </summary>
    void InitializeEffects()
    {
        foreach (EffectInfo e in effects)
        {
            if (e.effectPrefab != null && !effectDictionary.ContainsKey(e.effectName))
            {
                effectDictionary.Add(e.effectName, e.effectPrefab);
            }
        }
    }

    /// <summary>
    /// Gọi hiệu ứng theo tên
    /// </summary>
    public GameObject PlayEffect(string effectName, Vector3 position, Quaternion rotation, float duration = -1f)
    {
        if (!effectDictionary.ContainsKey(effectName))
        {
            Debug.LogWarning("Effect not found: " + effectName);
            return null;
        }

        GameObject prefab = effectDictionary[effectName];
        GameObject effectInstance = Instantiate(prefab, position, rotation);

        if (effectParent != null)
            effectInstance.transform.SetParent(effectParent);

        if (duration < 0)
        {
            EffectInfo eInfo = effects.Find(e => e.effectName == effectName);
            if (eInfo != null) duration = eInfo.defaultDuration;
            else duration = 2f;
        }

        Destroy(effectInstance, duration);
        return effectInstance;
    }

    /// <summary>
    /// Dùng khi cần gọi hiệu ứng từ GameManager
    /// </summary>
    public void PlayGameEventEffect(string eventName, Vector3 position)
    {
        // Ví dụ: "LevelUp", "BossSpawn", "Victory"
        PlayEffect(eventName, position, Quaternion.identity);
    }
}
