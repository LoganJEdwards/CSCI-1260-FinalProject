using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterHud : MonoBehaviour
{
    /// <summary>
    /// Text fields for displaying a characters stats to the hud
    /// </summary>
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI energyText;
    public TextMeshProUGUI skillText;
    public TextMeshProUGUI protText;
    public TextMeshProUGUI evasText;
    public TextMeshProUGUI speedText;
    
    /// <summary>
    /// This displays a characters stats as information the player can see in game.
    /// </summary>
    /// <param name="character">Character</param>
    public void SetCharHud(Character character)
    {
        nameText.text = character.charName;
        healthText.text = "Health: " + character.charCurrentHealth + "/" + character.charMaxHealth;
        energyText.text = "Energy: " + character.charCurrentEnergy + "/" + character.charMaxEnergy;
        skillText.text = "Skill: " + character.charSkill;
        protText.text = "Protection: " + character.charCurrentProt;
        evasText.text = "Evasion: " + character.charCurrentEvas;
        speedText.text = "Speed: " + character.charSpeed;
    }
}
