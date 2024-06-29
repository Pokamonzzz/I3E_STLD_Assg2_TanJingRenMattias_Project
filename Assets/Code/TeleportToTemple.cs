using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToTemple : MonoBehaviour
{
    public string targetSceneName = "TempleLevel"; // Name of the TempleLevel scene
    public Vector3 spawnPosition; // Specific location in TempleLevel scene
    public Vector3 spawnDirection; // Specific Direction in TempleLevel scene


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
    private void SaveSpawnPositionAndDirection()
    {
        PlayerPrefs.SetFloat("SpawnX", spawnPosition.x);
        PlayerPrefs.SetFloat("SpawnY", spawnPosition.y);
        PlayerPrefs.SetFloat("SpawnZ", spawnPosition.z);

        PlayerPrefs.SetFloat("SpawnDirX", spawnDirection.x);
        PlayerPrefs.SetFloat("SpawnDirZ", spawnDirection.z);
    }
}
