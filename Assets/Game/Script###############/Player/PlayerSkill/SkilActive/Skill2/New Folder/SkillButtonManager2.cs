using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButtonManager2 : MonoBehaviour {

	public GameObject skillButtonPrefab;
    public Transform skillButtonPanel;
    public List<SkillData> skills;

    void Start()
    {
        GenerateSkillButtons();
    }

    void GenerateSkillButtons()
    {
        foreach (SkillData skill in skills)
        {
            GameObject go = Instantiate(skillButtonPrefab, skillButtonPanel);
            SkillButtonUI2 buttonUI = go.GetComponent<SkillButtonUI2>();
            buttonUI.Init(skill);
        }
    }
}
