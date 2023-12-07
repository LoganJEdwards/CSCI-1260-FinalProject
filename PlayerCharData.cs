using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharData
{
    // Player Characters Name
    public string playCharName;

    // Player Characters Max possible health and current health
    public int playCharMaxHealth;
    public int playCharCurrentHealth;

    // Player Characters Max possible energy and current energy
    // Energy is used for certain abilities
    public int playCharMaxEnergy;
    public int playCharCurrentEnergy;

    // Player Character skill value 
    // Skill is used to determine how much damage is dealt
    public int playCharSkill;

    // Player Characters Max possible protection and current protection
    public double playCharProt;
    public double playCharCurrentProt;

    // Player Characters Max possible evasion and current evasion
    // Evasion will be a percent chance to negate any damage
    public double playCharEvas;
    public double playCharCurrentEvas;

    // Player Characters speed
    // Speed is what determines what character goes first
    public int playCharSpeed;

    public CharData(Character character)
    {
        playCharName = character.charName;

        playCharMaxHealth = character.charMaxHealth;
        playCharCurrentHealth = character.charCurrentHealth;

        playCharMaxEnergy = character.charMaxEnergy;
        playCharCurrentEnergy = character.charCurrentEnergy;

        playCharSkill = character.charSkill;

        playCharProt = character.charProt;
        playCharCurrentProt = character.charCurrentProt;

        playCharEvas = character.charEvas;
        playCharCurrentEvas = character.charCurrentEvas;

        playCharSpeed = character.charSpeed;
    }
}
