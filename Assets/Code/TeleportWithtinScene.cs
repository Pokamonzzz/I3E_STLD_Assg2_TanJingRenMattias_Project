/*
 * Author: Tan Jing Ren MAttias
 * Date: 30 June 2024
 * Description: Handles teleportation of the player within the same scene.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportWithinScene : MonoBehaviour
{
    /// <summary>
    /// Reference to the player's transform.
    /// </summary>
    public Transform player;

    /// <summary>
    /// Destination transform where the player will be teleported.
    /// </summary>
    public Transform destination;

    /// <summary>
    /// Reference to the player's game object.
    /// </summary>
    public GameObject playerg;

    /// <summary>
    /// Called when a collider enters the trigger.
    /// Teleports the player to the destination and manages player game object visibility.
    /// </summary>
    /// <param name="other">The collider entering the trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Deactivate player game object temporarily
            playerg.SetActive(false);

            // Teleport player to the destination position
            player.position = destination.position;

            // Reactivate player game object
            playerg.SetActive(true);
        }
    }

    /// <summary>
    /// Called on startup.
    /// Ensures that the player and player game object are not destroyed on scene load.
    /// </summary>
    private void Start()
    {
        if (player != null)
        {
            DontDestroyOnLoad(player.gameObject);
        }
        if (playerg != null)
        {
            DontDestroyOnLoad(playerg);
        }
    }
}