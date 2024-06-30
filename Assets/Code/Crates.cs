/*
 * Author: Tan Jing Ren Mattias
 * Date: 27 June 2024
 * Description: Crates in the game that spawns items when destroyed.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the behavior of crates in the game, including spawning collectibles and showing the win UI.
/// </summary>
public class Crates : MonoBehaviour
{
    /// <summary>
    /// The collectible prefab to spawn.
    /// </summary>
    [SerializeField]
    private GameObject spawn;

    /// <summary>
    /// The specific spawn point for the collectible.
    /// </summary>
    [SerializeField]
    private Transform spawnPoint;

    /// <summary>
    /// Reference to the UI element to show when the collectible spawns.
    /// </summary>
    [SerializeField]
    private GameObject winUI; // Reference to the UI element to show when the crystal spawns

    /// <summary>
    /// Handles collisions with other game objects.
    /// </summary>
    /// <param name="other">The collider of the object that enters the trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            SpawnCollectible();
            Destroy(gameObject); // Destroy this crate after spawning the collectible
        }
        if (other.CompareTag("Player"))
        {
            SpawnCollectible();
            Destroy(gameObject); // Destroy this crate after spawning the collectible
        }
    }

    /// <summary>
    /// Spawns the collectible and shows the win UI element.
    /// </summary>
    void SpawnCollectible()
    {
        if (spawnPoint != null)
        {
            // Instantiate the collectible prefab at the spawn point's position and rotation
            Instantiate(spawn, spawnPoint.position, spawnPoint.rotation);

            // Show the win UI element
            if (winUI != null)
            {
                winUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
