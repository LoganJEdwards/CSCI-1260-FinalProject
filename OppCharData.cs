using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// I dont think I ever used this but left it just incase.
/// </summary>
[System.Serializable]
public class OppCharData
{
    // Opponent Characters Name
    public string oppCharName;

    // Opponent Characters Max possible health and current health
    public int oppCharMaxHealth;
    public int oppCharCurrentHealth;

    // Opponent Characters Max possible energy and current energy
    // Energy is used for certain abilities
    public int oppCharMaxEnergy;
    public int oppCharCurrentEnergy;

    // Opponent Character skill value 
    // Skill is used to determine how much damage is dealt
    public int oppCharSkill;

    // Opponent Characters Max possible protection and current protection
    public double oppCharProt;
    public double oppCharCurrentProt;

    // Opponent Characters Max possible evasion and current evasion
    // Evasion will be a percent chance to negate any damage
    public double oppCharEvas;
    public double oppCharCurrentEvas;

    // Opponent Characters speed
    // Speed is what determines what character goes first
    public int oppCharSpeed;

    public OppCharData(Character character)
    {
        oppCharName = character.charName;

        oppCharMaxHealth = character.charMaxHealth;
        oppCharCurrentHealth = character.charCurrentHealth;

        oppCharMaxEnergy = character.charMaxEnergy;
        oppCharCurrentEnergy = character.charCurrentEnergy;

        oppCharSkill = character.charSkill;

        oppCharProt = character.charProt;
        oppCharCurrentProt = character.charCurrentProt;

        oppCharEvas = character.charEvas;
        oppCharCurrentEvas = character.charCurrentEvas;

        oppCharSpeed = character.charSpeed;
    }
}
