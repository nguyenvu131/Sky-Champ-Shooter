using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPetStats", menuName = "ScriptableObjects/PetStats")]
public class PetStatsSO : ScriptableObject
{
	public string petName;
	public float followDistance = 2f;
	public float moveSpeed = 0.5f;
	public float fireRate = 1f;
	public GameObject bulletPrefab;
	public int damage = 10;
}
