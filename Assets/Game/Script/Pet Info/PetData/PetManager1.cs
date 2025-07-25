using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager1 : MonoBehaviour {

	public GameObject[] petPrefabs;
	private List<GameObject> activePets = new List<GameObject>();

	void Start() {
		SpawnAllPets();
	}

	public void SpawnAllPets() {
		for (int i = 0; i < petPrefabs.Length; i++) {
			GameObject pet = Instantiate(petPrefabs[i], transform.position, Quaternion.identity);
			pet.transform.SetParent(transform); // Gắn theo Player
			activePets.Add(pet);
		}
	}
}
