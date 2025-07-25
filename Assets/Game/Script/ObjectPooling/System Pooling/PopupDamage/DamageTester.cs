using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTester : MonoBehaviour
{
	public MonsterStats stats;	
    public Monster monster;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (monster != null) // ✅ Check tránh lỗi
            {
                monster.TakeDamage(Random.Range(5, 20));
            }
        }
    }
}
