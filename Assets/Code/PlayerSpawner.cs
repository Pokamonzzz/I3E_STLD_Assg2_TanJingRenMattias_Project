/*
 * Author: Tan Jing Ren Mattias
 * Date: 23 June 2024
 * Description: Handles spawning and respawning of the player based on saved positions.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    /// <summary>
    /// Spawnposition in the unity scene
    /// </summary>
    private Vector3 initialSpawnPosition;

    /// <summary>
    /// spawn rotation in unity scene
    /// </summary>
    private Quaternion initialSpawnRotation;

    /// <summary>
    /// Find the spawnpoistion and spawn the player there by getting from where the player first spawn
    /// </summary>
    private void Awake()
    {
        initialSpawnPosition = transform.position;
        initialSpawnRotation = transform.rotation;

        // Check if there are saved spawn positions
        if (PlayerPrefs.HasKey("SpawnX") && PlayerPrefs.HasKey("SpawnY") && PlayerPrefs.HasKey("SpawnZ")
            && PlayerPrefs.HasKey("SpawnDirX") && PlayerPrefs.HasKey("SpawnDirZ"))
        {
            Vector3 spawnPosition = new Vector3(
                PlayerPrefs.GetFloat("SpawnX"),
                PlayerPrefs.GetFloat("SpawnY"),
                PlayerPrefs.GetFloat("SpawnZ")
            );

            Vector3 spawnDirection = new Vector3(
                PlayerPrefs.GetFloat("SpawnDirX"),
                0f, // Y-axis rotation not stored, assuming flat rotation
                PlayerPrefs.GetFloat("SpawnDirZ")
            );

            // Find the player and set its position to the spawn point
            Player player = FindObjectOfType<Player>(); // Adjust this based on your player setup
            if (player != null)
            {
                player.transform.position = spawnPosition;
                player.transform.forward = spawnDirection.normalized;
                Debug.Log($"Spawned player at: {spawnPosition} with rotation: {spawnDirection} in {SceneManager.GetActiveScene().name} scene.");
            }
            else
            {
                Debug.LogWarning("Player not found for spawning.");
            }

            // Remove saved spawn positions after use
            PlayerPrefs.DeleteKey("SpawnX");
            PlayerPrefs.DeleteKey("SpawnY");
            PlayerPrefs.DeleteKey("SpawnZ");
            PlayerPrefs.DeleteKey("SpawnDirX");
            PlayerPrefs.DeleteKey("SpawnDirZ");
        }
        else
        {
            Debug.LogWarning("No spawn position saved for TempleLevel scene.");
        }
    }

    /// <summary>
    /// Respawns the player at the initial spawn position.
    /// </summary>
    public void RespawnPlayerAtInitialSpawn()
    {
        Player player = FindObjectOfType<Player>(); // Find the player in the scene
        if (player != null)
        {
            player.transform.position = initialSpawnPosition;
            player.transform.rotation = initialSpawnRotation;
            Debug.Log($"Player respawned at initial spawn: {initialSpawnPosition} with rotation: {initialSpawnRotation}.");
        }
        else
        {
            Debug.LogWarning("Player not found for respawning.");
        }
    }
}
