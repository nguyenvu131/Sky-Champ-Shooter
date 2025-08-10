using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManagerMonster : MonoBehaviour
{
	public static SkillManagerMonster Instance { get; private set; }
	 
    public GameObject fireNovaPrefab;
    public Transform playerTransform;
	
	void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Các method ví dụ:	
    public void CastFireNova()
    {
        if (fireNovaPrefab != null && playerTransform != null)
        {
            Instantiate(fireNovaPrefab, playerTransform.position, Quaternion.identity);
            Debug.Log("Fire Nova casted!");
        }
        else
        {
            Debug.LogWarning("Missing fireNovaPrefab or playerTransform!");
        }
    }
	
	public void ActivateShield()
	{
		ShieldController shield = playerTransform.GetComponent<ShieldController>();
		if (shield != null)
		{
			shield.ActivateShield();
		}
		else
		{
			Debug.LogWarning("No ShieldController found on player!");
		}
	}
	
	public void FreezeEnemies(float freezeDuration = 3f)
    {
        Debug.Log("Freezing all enemies for " + freezeDuration + " seconds!");

        // Tìm tất cả enemy trong scene (ví dụ tag "Enemy")
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            EnemyFreezeController freezeController = enemy.GetComponent<EnemyFreezeController>();
            if (freezeController != null)
            {
                freezeController.Freeze(freezeDuration);
            }
        }
    } 
}	
