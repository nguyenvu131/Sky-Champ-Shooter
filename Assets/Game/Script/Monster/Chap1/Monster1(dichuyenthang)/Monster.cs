using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour 
{
	
	public MonsterStats stats; // sẽ hiển thị đầy đủ trong Inspector
	public GameObject uiPrefab;
    public GameObject uiInstance;
	public Text textLevel;
    public Text textHP;
	public PopupDamageSpawner popupSpawner;
	
	public int level = 1;
	public int monsterLevel = 1;
	public float currentHP;     
    public float moveSpeed;
    public float damage;
    public float attackDelay;
	
	public string dropType = "Coin"; // có thể là "Gem", "Item"
	
	void Start()
    {	
		
        stats.currentHP = stats.maxHP;
		
		CreateUI();
		UpdateUI();
        
		// Nếu chưa gán thủ công trong Inspector, tự tìm trong scene
        if (popupSpawner == null)
        {
            popupSpawner = FindObjectOfType<PopupDamageSpawner>();
        }
		stats = new MonsterStats(monsterLevel);
        // Áp dụng stats cho monster
        currentHP = stats.hp;
        moveSpeed = stats.moveSpeed;
        attackDelay = stats.attackSpeed;
        damage = stats.damage;

        // Hiển thị chỉ số hoặc debug
        Debug.Log("Monster Lv" + level + " | HP: " + stats.hp + " | DMG: " + stats.damage);
		
    }

    public void TakeDamage(float damage)
    {
        float finalDamage = damage - stats.defense;
        finalDamage = Mathf.Max(finalDamage, 1);

        stats.currentHP -= finalDamage;
		
		// Gọi popup text
		// Vector3 popupPos = uiFollowPoint.position + new Vector3(0, 1f, 0); // trên đầu quái
		// PopupTextPoolManager.Instance.SpawnPopup("damage", popupPos, "-" + damage);
        
		// GỌI POPUP DAMAGE tại vị trí quái
        if (popupSpawner != null)
        {
           FindObjectOfType<PopupDamageSpawner>().ShowDamage((int)damage, this.transform);
        }
		
		//
		UpdateUI();
		UpdateEffect();
		
        if (stats.currentHP <= 0 || stats.hp <= 0)
		{
			Die();
		}
    }

    void Die()
    {
		//
		Vector3 effectPos = transform.position;
		EffectPoolManager.Instance.SpawnEffect("explosion", effectPos, Quaternion.identity);
		//
		DropItemPoolManager.Instance.SpawnItem("Coin", transform.position);
        Destroy(gameObject); // hoặc gameObject.SetActive(false) nếu dùng pooling quái
		
        Debug.Log(gameObject.name + " has died!");
        Destroy(gameObject);
    }
	
	void UpdateUI()
    {
		
        if (textLevel != null)
            textLevel.text = "Lv. " + stats.level;

        if (textHP != null)
            textHP.text = stats.currentHP + " / " + stats.maxHP;
    }
	
	void CreateUI()
    {
        if (uiPrefab == null)
            uiPrefab = Resources.Load<GameObject>("UI/UI_MonsterInfo");

        // Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        // uiInstance = Instantiate(uiPrefab, canvas.transform);

        // Set follow target
        // MonsterUIFollow follow = uiInstance.GetComponent<MonsterUIFollow>();
        // follow.target = this.transform;

        // Get text references
        // textLevel = uiInstance.transform.Find("Text_Level").GetComponent<Text>();
        // textHP = uiInstance.transform.Find("Text_HP").GetComponent<Text>();
    }
	
	void UpdateEffect()
	{
		// Hiệu ứng trúng đòn
		Vector3 hitPos = transform.position;
		EffectPoolManager.Instance.SpawnEffect("hit", hitPos, Quaternion.identity);
	}
	
	void OnDestroy()
    {
        if (uiInstance != null)
            Destroy(uiInstance);
    }
}
