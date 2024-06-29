/*
 * Author: 
 * Date: 23 June 2024
 * Description: 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int targetSceneIndex; // Index of the TempleLevel scene in the build settings
    public Transform spawnPointTempleLevel; // Reference to the spawn point in the TempleLevel scene

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Teleport to TempleLevel scene
            TeleportToTempleLevel();
        }
    }

    private void TeleportToTempleLevel()
    {
        // Set spawn index or position if needed before loading scene
        SpawnManager.instance.SetSpawnIndexTempleLevel(0); // Example: Set spawn index if using SpawnManager

        // Load the TempleLevel scene
        SceneManager.LoadScene(targetSceneIndex);
    }
}

