using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Khi bắn trúng quái
// EffectManager.Instance.PlayEffect("Hit_Lv1", hitPosition);

// Khi quái chết
// EffectManager.Instance.PlayEffect("Explosion_Lv1", transform.position);

// Khi player dùng boost
// EffectManager.Instance.PlayEffect("Trail_Lv2", player.transform.position, player.transform);

public class EffectManager : MonoBehaviour {

	public static EffectManager Instance;

    private Dictionary<string, EffectData> effectDict = new Dictionary<string, EffectData>();

    void Awake() {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        LoadAllEffects();
    }

    void LoadAllEffects() {
        EffectData[] allEffects = Resources.LoadAll<EffectData>("Effects");

        foreach (EffectData effect in allEffects) {
            if (!effectDict.ContainsKey(effect.effectID)) {
                effectDict.Add(effect.effectID, effect);
            }
        }
    }

    public void PlayEffect(string effectID, Vector3 pos, Transform parent = null) {
        if (effectDict.ContainsKey(effectID)) {
            EffectData effect = effectDict[effectID];

            GameObject fx = Instantiate(effect.prefab, pos, Quaternion.identity);
            if (parent != null) fx.transform.SetParent(parent);

            if (effect.sfx != null)
                AudioSource.PlayClipAtPoint(effect.sfx, pos);

            Destroy(fx, effect.duration);
        } else {
            Debug.LogWarning("Effect ID not found: " + effectID);
        }
    }
}
