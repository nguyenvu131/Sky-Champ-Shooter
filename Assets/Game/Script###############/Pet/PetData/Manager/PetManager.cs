using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : Singleton<PetManager> 
{

	// public static PetManager Instance;

    public Transform petLeftSlot;
    public Transform petRightSlot;

    public List<PetData> ownedPets;
    private GameObject currentPetLeft;
    private GameObject currentPetRight;

    // void Awake() {
        // if (Instance == null) Instance = this;
        // else Destroy(gameObject);
    // }

    void Start() {
        SpawnActivePets();
    }

    public void SpawnActivePets() {

		if (ownedPets == null || ownedPets.Count == 0)
		{
			Debug.LogWarning("PetManager: ownedPets is null or empty!");
			return;
		}

		PetData leftPet = ownedPets.Count > 0 ? ownedPets[0] : null;
		PetData rightPet = ownedPets.Count > 1 ? ownedPets[1] : null;

		if (leftPet != null)
			

		if (rightPet != null)
				

		
        if (ownedPets.Count > 0) {
            currentPetLeft = Instantiate(ownedPets[0].prefab, petLeftSlot.position, Quaternion.identity, petLeftSlot);
            currentPetLeft.GetComponent<PetController>().Setup(ownedPets[0]);
        }

        if (ownedPets.Count > 1) {
            currentPetRight = Instantiate(ownedPets[1].prefab, petRightSlot.position, Quaternion.identity, petRightSlot);
            currentPetRight.GetComponent<PetController>().Setup(ownedPets[1]);
        }
    }

    public void DespawnPets() {
        if (currentPetLeft) Destroy(currentPetLeft);
        if (currentPetRight) Destroy(currentPetRight);
    }
}
