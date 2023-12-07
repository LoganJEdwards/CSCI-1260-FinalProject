using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnBehavior
{
    /// <summary>
    /// Queue made for the character class named turnOrder
    /// </summary>
    public Queue<Character> turnOrder;

    /// <summary>
    /// Creates a new Queue as turnOrder
    /// </summary>
    public TurnBehavior()
    {
        turnOrder = new Queue<Character>();
    }

    /// <summary>
    ///  Sorts all charactersalready in the queue and based upon their speed value
    ///  to determine who is queued first
    /// </summary>
    private void SortQueue()
    {
        turnOrder = new Queue<Character>(turnOrder.OrderByDescending(character => character.charSpeed));
    }

    /// <summary>
    /// Queues a character into the turnOrder Queue
    /// </summary>
    /// <param name="character"></param>
    public void Enqueue(Character character)
    {
        turnOrder.Enqueue(character);
        SortQueue();
    }

    /// <summary>
    /// Unqueues a character from the turnorder queue
    /// </summary>
    /// <returns></returns>
    public Character Dequeue()
    {
        return turnOrder.Dequeue();
    }

    /// <summary>
    /// Returns the oldest character in the queue
    /// </summary>
    /// <returns>Character</returns>
    public Character PeekQueue()
    {
        return turnOrder.Peek();
    }
    
}
