using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    private Vector3 initialSpawnPosition;
    private Quaternion initialSpawnRotation;

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
                PlayerPrefs.GetFloat("SpawnDirZ")
            );

            // Find the player and set its position to the spawn point
            Player player = FindObjectOfType<Player>(); // Adjust this based on your player setup
            if (player != null)
            {
                player.transform.position = spawnPosition;
                player.transform.forward = spawnDirection;
                Debug.Log($"Spawned player at: {spawnPosition} with rotation: {spawnDirection} in {SceneManager.GetActiveScene().name} scene.");
            }
            else
            {
                Debug.LogWarning("Player not found for spawning.");
            }
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
