using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetItemUI : MonoBehaviour {

	public Image iconImage;
    public Text levelText;
    public Button assignLeftButton;
    public Button assignRightButton;

    private PetData petData;
    private PetSelectUI parent;

    public void Setup(PetData data, PetSelectUI ui) {
        petData = data;
        parent = ui;

        iconImage.sprite = petData.icon;
        levelText.text = "Lv " + petData.level;

        assignLeftButton.onClick.AddListener(() => parent.AssignPetLeft(petData));
        assignRightButton.onClick.AddListener(() => parent.AssignPetRight(petData));
    }
}
