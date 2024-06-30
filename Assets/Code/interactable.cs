/*
 * Author: Tan Jing Ren Mattias
 * Date: 27 June 2024
 * Description: Base class for objects that can be interacted with by the player.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    /// <summary>
    /// Called when the object is interacted with by the player.
    /// </summary>
    /// <param name="player">The player interacting with the object.</param>
    public virtual void Interacted(Player player)
    {
        Debug.Log($"{gameObject.name} interacted by {player.gameObject.name}");

        // Play interaction sound if AudioManager instance exists
        AudioManager.instance?.Effects(AudioManager.instance.collect);
    }
}
