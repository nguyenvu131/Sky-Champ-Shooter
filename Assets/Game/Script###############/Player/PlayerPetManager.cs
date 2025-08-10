using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPetManager : MonoBehaviour {

	public GameObject[] petPrefabs;
	private List<GameObject> activePets = new List<GameObject>();

	void Start() {
		foreach (GameObject petPrefab in petPrefabs) {
			GameObject pet = Instantiate(petPrefab, transform.position, Quaternion.identity);
			pet.transform.SetParent(transform);
			activePets.Add(pet);
		}
	}
}
