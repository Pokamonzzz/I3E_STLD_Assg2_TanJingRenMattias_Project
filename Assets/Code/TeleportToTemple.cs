/*
 * Author: Tan Jing Ren Mattias
 * Date: 30 June 2024
 * Description: Handles teleportation to the TempleLevel scene and saves spawn positions.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToTemple : MonoBehaviour
{
    /// <summary>
    /// Name of the target scene to teleport to (default: "TempleLevel").
    /// </summary>
    public string targetSceneName = "TempleLevel";

    /// <summary>
    /// Specific spawn position in the TempleLevel scene.
    /// </summary>
    public Vector3 spawnPosition;

    /// <summary>
    /// Specific spawn direction in the TempleLevel scene.
    /// </summary>
    public Vector3 spawnDirection;

    /// <summary>
    /// Called when a collider enters the trigger.
    /// Checks if the collider is the player, saves spawn position and direction, and loads the TempleLevel scene.
    /// </summary>
    /// <param name="other">The collider entering the trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Save the spawn position and rotation for TempleLevel scene
            SaveSpawnPositionAndDirection();

            // Load TempleLevel scene
            SceneManager.LoadScene(targetSceneName);
        }
    }

    /// <summary>
    /// Saves the spawn position and direction for the TempleLevel scene in PlayerPrefs.
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
