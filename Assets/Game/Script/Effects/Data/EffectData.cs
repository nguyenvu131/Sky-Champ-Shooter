using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectType {
    Hit,
    Explosion,
    Trail,
    Buff,
    Skill,
    Screen
}

[CreateAssetMenu(fileName = "NewEffect", menuName = "Effect/Effect Data")]
public class EffectData : ScriptableObject {
    public string effectID;
    public EffectType type;
    public GameObject prefab;
    public AudioClip sfx;
    public float duration = 1f;
}
