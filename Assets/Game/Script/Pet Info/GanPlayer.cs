using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GanPlayer : MonoBehaviour {

	public GameObject petPrefab;
	public PetStatsSO selectedPet;

	void Start()
	{
		SpawnPet();
	}

	void SpawnPet()
	{
		GameObject pet = Instantiate(petPrefab, transform.position, Quaternion.identity);
		pet.GetComponent<PetController>().target = this.transform;
		pet.GetComponent<PetController>().stats = selectedPet;
	}
}
