using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSelectUI : MonoBehaviour {

	public Transform contentContainer;
    public GameObject petItemUIPrefab;

    void OnEnable() {
        LoadPetList();
    }

    void LoadPetList() {
        foreach (Transform child in contentContainer)
            Destroy(child.gameObject);

        foreach (PetData pet in PetManager.Instance.ownedPets) {
            GameObject obj = Instantiate(petItemUIPrefab, contentContainer);
            PetItemUI itemUI = obj.GetComponent<PetItemUI>();
            itemUI.Setup(pet, this);
        }
    }

    public void AssignPetLeft(PetData pet) {
        Debug.Log("Gán Pet trái: " + pet.id);
        PetManager.Instance.ownedPets[0] = pet;
        PetManager.Instance.DespawnPets();
        PetManager.Instance.SpawnActivePets();
    }

    public void AssignPetRight(PetData pet) {
        Debug.Log("Gán Pet phải: " + pet.id);
        if (PetManager.Instance.ownedPets.Count < 2)
            PetManager.Instance.ownedPets.Add(pet);
        else
            PetManager.Instance.ownedPets[1] = pet;

        PetManager.Instance.DespawnPets();
        PetManager.Instance.SpawnActivePets();
    }
}
