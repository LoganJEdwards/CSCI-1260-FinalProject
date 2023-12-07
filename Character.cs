using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Characters Name
    public string charName;

    // Characters Max possible health and current health
    public int charMaxHealth;
    public int charCurrentHealth;

    // Characters Max possible energy and current energy
    // Energy is used for certain abilities
    public int charMaxEnergy;
    public int charCurrentEnergy;

    // Character skill value 
    // Skill is used to determine how much damage is dealt
    public int charSkill;

    // Characters Max possible protection and current protection
    public double charProt;
    public double charCurrentProt;

    // Characters Max possible evasion and current evasion
    // Evasion will be a percent chance to negate any damage
    public double charEvas;
    public double charCurrentEvas;

    // Characters speed
    // Speed is what determines what character goes first
    public int charSpeed;

    /// <summary>
    /// Constructor for the Character class
    /// </summary>
    /// <param name="charName">string</param>
    /// <param name="charMaxHealth">int</param>
    /// <param name="charCurrentHealth">int</param>
    /// <param name="charMaxEnergy">int</param>
    /// <param name="charCurrentEnergy">int</param>
    /// <param name="charSkill">int</param>
    /// <param name="charProt">double</param>
    /// <param name="charCurrentProt">double</param>
    /// <param name="charEvas">double</param>
    /// <param name="charCurrentEvas">double</param>
    /// <param name="charSpeed">int</param>
    public Character(string charName, int charMaxHealth, int charCurrentHealth, int charMaxEnergy, int charCurrentEnergy, int charSkill, double charProt, double charCurrentProt, double charEvas, double charCurrentEvas, int charSpeed)
    {
        this.charName = charName;
        this.charMaxHealth = charMaxHealth;
        this.charCurrentHealth = charCurrentHealth;
        this.charMaxEnergy = charMaxEnergy;
        this.charCurrentEnergy = charCurrentEnergy;
        this.charSkill = charSkill;
        this.charProt = charProt;
        this.charCurrentProt = charCurrentProt;
        this.charEvas = charEvas;
        this.charCurrentEvas = charCurrentEvas;
        this.charSpeed = charSpeed;
    }

    /// <summary>
    /// Takes the characters evasion and grabs a random number from 1 to 100 and if the random number is less than the evasion they dodge
    /// </summary>
    /// <param name="dodgeChance">double</param>
    /// <returns>bool</returns>
    private bool Dodge(double dodgeChance)
    {
        System.Random random = new System.Random();
        double randomNumber = random.Next(0, 101);

        return randomNumber <= dodgeChance;

    }

    /// <summary>
    /// Uses the characters whose attacking skill to determine damage, the character who is being attacked has that damage mitigated by a percent of their protection value and 
    /// calls the dodge method to see if that character completly negated any damage, then checks if the character that was attacked is dead.
    /// </summary>
    /// <param name="damage">int</param>
    /// <returns>bool</returns>
    public bool TakeDamage(int damage)
    {
        int incomingDmg = charSkill;

        int mitigatedDamage = ((int)(incomingDmg * (1.0 - (charCurrentProt / 100))));

        if (Dodge(charCurrentEvas))
        {
            return false;
        }

        charCurrentHealth -= mitigatedDamage;
        
        if (charCurrentHealth <= 0)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Saves the data and stats of both the player and the opponent as a JSON and make the player data on one line the the
    /// opponent data on the next
    /// </summary>
    /// <param name="isAppend"></param>
    public void GameSave(bool isAppend)
    {
        SaveGame.PlaySaveGame(this, isAppend);

    }
}


    