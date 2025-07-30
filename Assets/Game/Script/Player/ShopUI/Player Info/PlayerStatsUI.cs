using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour 
{
    public Text levelText;
    public Text hpText;
    public Text mpText;
    public Text attackText;
    public Text defenseText;
	public Player player;
	public Text textHP;
	public Text textATK;
	public Text textDEF;
	public Text textLevel;
	public Text textEXPValue;

    public void UpdateUI(PlayerStats stats)
    {
        // levelText.text = "Level: " + stats.level;
        // hpText.text = " HP " + stats.currentHP + " / " + stats.maxHP;
        // mpText.text = " MP " + stats.currentMP + " / " + stats.maxMP;
        // attackText.text = "ATK: " + stats.attack;
        // defenseText.text = "DEF: " + stats.defense;
		if (player != null && player.stats != null)
        {
            textHP.text = "HP: " + player.stats.currentHP + " / " + player.stats.maxHP;
            textATK.text = "ATK: " + player.stats.attack;
            textDEF.text = "DEF: " + player.stats.defense;
			textLevel.text = "Level " + player.stats.level;
			textEXPValue.text = player.stats.exp + " / " + player.stats.expToNextLevel;
        }
    }
}
