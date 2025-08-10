using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Skill/Create New Skill")]
public class SkillData : ScriptableObject
{
    public string skillName;
    public GameObject skillPrefab;
    public float cooldown;
    public float duration;
	public Sprite icon;
	public int level = 1; 
	public int skillID;
}
