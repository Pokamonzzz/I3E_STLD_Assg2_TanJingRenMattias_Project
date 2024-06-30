/*
 * Author: Tan Jing Ren Mattias
 * Date: 30 June 2024
 * Description: Handles teleportation functionality and saves spawn positions.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToCastle : MonoBehaviour
{
    /// <summary>
    /// Name of the target scene to teleport to (default: "CastleLevel").
    /// </summary>
    public string targetSceneName = "CastleLevel";

    /// <summary>
    /// Specific spawn position in the CastleLevel scene.
    /// </summary>
    public Vector3 spawnPosition;

    /// <summary>
    /// Specific spawn direction in the CastleLevel scene.
    /// </summary>
    public Vector3 spawnDirection;

    /// <summary>
    /// Called when a collider enters the trigger.
    /// Checks if the collider is the player, saves spawn position and direction, and loads the CastleLevel scene.
    /// </summary>
    /// <param name="other">The collider entering the trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Save the spawn position and rotation for CastleLevel scene
            SaveSpawnPositionAndDirection();

            // Load CastleLevel scene
            SceneManager.LoadScene(targetSceneName);
        }
    }

    /// <summary>
    /// Saves the spawn position and direction for the CastleLevel scene in PlayerPrefs.
    /// </summary>
    private void SaveSpawnPositionAndDirection()
    {
        PlayerPrefs.SetFloat("SpawnX", spawnPosition.x);
        PlayerPrefs.SetFloat("SpawnY", spawnPosition.y);
        PlayerPrefs.SetFloat("SpawnZ", spawnPosition.z);

        PlayerPrefs.SetFloat("SpawnDirX", spawnDirection.x);
        PlayerPrefs.SetFloat("SpawnDirZ", spawnDirection.z);
    }
}