using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class BattleSystem : MonoBehaviour
{
    /// <summary>
    /// creates a turnQueue field of the TurnBehavior class
    /// </summary>
    private TurnBehavior turnQueue;

    /// <summary>
    /// Creates a field of a unity gameobject class
    /// </summary>
    public GameObject playerPrefab;
    public GameObject opponentPrefab;

    /// <summary>
    /// Retrieves the x, y, z location of the battle station for the respective character
    /// </summary>
    public Transform playerBattleStation;
    public Transform opponentBattleStation;

    Character playerUnit;
    Character opponentUnit;

    /// <summary>
    /// Creates a field for both opponent and player so that will be used so that their stats can be displayed
    /// </summary>
    public CharacterHud playerHud;
    public CharacterHud opponentHud;

    /// <summary>
    /// Used to display text to the dialogue panel.
    /// </summary>
    public TextMeshProUGUI dialogueText;

    public GameObject[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetupBattle());
    }

    /// <summary>
    /// Creates the battle scene by loading in the player prefab and the opponent prefab along with their stats
    /// </summary>
    /// <returns></returns>
    IEnumerator SetupBattle()
    {
        // Spawn the player/opponent as a child atop of their respected spot
        GameObject playerObj = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerObj.GetComponent<Character>();

        GameObject opponentObj = Instantiate(opponentPrefab, opponentBattleStation);
        opponentUnit = opponentObj.GetComponent<Character>();

        //Displays each characters stats to their own hud panels
        playerHud.SetCharHud(playerUnit);
        opponentHud.SetCharHud(opponentUnit);

        //This displays itself to the dialogue panel when the enemy is first encountered
        dialogueText.text = "A " + opponentUnit.charName + " appears";

        //Creates a Queue for the players to be enqueued into then is sorted based upon their speed after each enqueue
        turnQueue = new TurnBehavior();

        turnQueue.Enqueue(playerUnit);
        turnQueue.Enqueue(opponentUnit);

        //This makes the game wait, so that the player has a chance to read the information displayed to the dialogue panel
        yield return new WaitForSeconds(1f);

        turnQueue.Dequeue();

        FirstTurn();
            
    }

    /// <summary>
    /// 
    /// </summary>
    void FirstTurn()
    {
        if (turnQueue.PeekQueue().charName != playerUnit.charName)
        {
            PlayerTurn();
        }
        else StartCoroutine(OpponentsTurn());
    }
    /// <summary>
    /// Displays text to the dialogue panel
    /// </summary>
    void PlayerTurn()
    {
        dialogueText.text = "What will you do?";
    }

    /// <summary>
    /// Calls the attack action method, Start coroutine intentional use is for animations to proceed while the method called is happening
    /// </summary>
    public void OnAttackButton()
    {
        StartCoroutine(AttackAction());
    }

    /// <summary>
    /// Calls the attack defend method not emplemented
    /// </summary>
    public void OnDefendButton()
    {
        if (turnQueue.PeekQueue() != playerUnit)
            return;

        StartCoroutine(DefendAction());
    }

    /// <summary>
    /// Calls the attack weaken method not emplemented
    /// </summary>
    public void OnWeakenButton()
    {
        if (turnQueue.PeekQueue() != playerUnit)
            return;

        StartCoroutine(WeakenAction());
    }

    /// <summary>
    /// Calls the attack Rend method not emplemented
    /// </summary>
    public void OnRendButton()
    {
        if (turnQueue.PeekQueue() != playerUnit)
            return;

        StartCoroutine(RendAction());
    }

    /// <summary>
    /// Calls the attack Heal method, not emplemented
    /// </summary>
    public void OnHealButton()
    {
        if (turnQueue.PeekQueue() != playerUnit)
            return;

        StartCoroutine(HealAction());
    }

    /// <summary>
    /// Updates the opponents hud for the damaged recieved from the attack and then checks to see if the opponent has died
    /// if the opponent has died it will end the encounter if not the opponent will take their turn
    /// </summary>
    /// <returns></returns>
    IEnumerator AttackAction()
    {

        ChangeStateButtons(false);

        bool hasDied = opponentUnit.TakeDamage(playerUnit.charSkill);
        opponentHud.SetCharHud(opponentUnit);

        yield return new WaitForSeconds (1f);

        if (hasDied)
        {
            EndEncounter();
        }
        else
        {
            StartCoroutine(OpponentsTurn());
        }
    }
    /// <summary>
    ///  not emplemented
    /// </summary>
    /// <returns></returns>
    IEnumerator DefendAction()
    {

        yield return new WaitForSeconds(1f);

    }

    /// <summary>
    ///  not emplemented
    /// </summary>
    /// <returns></returns>
    IEnumerator WeakenAction()
    {

        yield return new WaitForSeconds(1f);

    }

    /// <summary>
    ///  not emplemented
    /// </summary>
    /// <returns></returns>
    IEnumerator RendAction()
    {

        yield return new WaitForSeconds(1f);

    }

    /// <summary>
    ///  not emplemented
    /// </summary>
    /// <returns></returns>
    IEnumerator HealAction()
    {

        yield return new WaitForSeconds(1f);

    }

    /// <summary>
    /// When its the opponents turn  they will attack and call the take damage method this will then modify the players hud for how much damage they took and adjust their hud based upon the value
    /// it will then check to see if the player died if they did it will end the encounter to the lost screen if not it will continue to the players turn.
    /// </summary>
    /// <returns></returns>
    IEnumerator OpponentsTurn()
    {

        

        dialogueText.text = opponentUnit.charName + " attacked!";
        yield return new WaitForSeconds(1f);

        bool hasDied = playerUnit.TakeDamage(opponentUnit.charSkill);
        playerHud.SetCharHud(playerUnit);

        if (hasDied)
        {
            EndEncounter();
        }
        else
        {
            PlayerTurn();
        }

        ChangeStateButtons(true);
    }

    /// <summary>
    /// Changes the state of the buttons so the player cannot press them during the opponents turn
    /// </summary>
    /// <param name="enabled"></param>
    private void ChangeStateButtons(bool enabled)
    {
        foreach (GameObject button in this.buttons)
        {
            button.SetActive(enabled);
        }
    }

    /// <summary>
    /// This will display text to the dialogue box and will end the encounter in two different ways depending on if the player or the opponents health is at or below zero
    /// </summary>
    /// <returns></returns>
    IEnumerator EndEncounter()
    {
       if (playerUnit.charCurrentHealth <= 0)
       {
            dialogueText.text = "You have died!";
            yield return new WaitForSeconds(2f);
        
       }
       else if (opponentUnit.charCurrentHealth <= 0)
       {
            dialogueText.text = "You have won the encounter!";
            yield return new WaitForSeconds(2f);
       }
    }

    /// <summary>
    /// Saves both the player and opponents stats 
    /// </summary>
    public void Save()
    {
        SaveGame.PlaySaveGame(playerUnit, false);
        SaveGame.PlaySaveGame(opponentUnit, true);
    }

    /// <summary>
    /// Loads the stats of both characters and then updates the hud
    /// </summary>
    public void Load()
    {
        CharData[] loadedData = SaveGame.LoadPlayChar();

        playerUnit = SaveGame.ConvertData(loadedData[0], playerUnit);
        opponentUnit = SaveGame.ConvertData(loadedData[1], opponentUnit);
        playerHud.SetCharHud(playerUnit);
        opponentHud.SetCharHud(opponentUnit);

    }
}
