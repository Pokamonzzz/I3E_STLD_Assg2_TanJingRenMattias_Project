/*
 * Author: Tan Jing Ren Mattias
 * Date: 26 June 2024
 * Description: Manages healing items that restore health to the player on trigger enter.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    /// <summary>
    /// Amount of health restored by the healing item.
    /// </summary>
    public float healAmount = 5f;

    /// <summary>
    /// Trigger enter event handling for collision with the player.
    /// </summary>
    /// <param name="other">The collider of the other object.</param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called with: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player tag detected.");
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.HealPlayer(healAmount);
                Debug.Log("Healing player. Current health: " + player.currentHealth);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("Player component not found on the Player.");
            }
        }
    }
}
