using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToCastle : MonoBehaviour
{
    public string targetSceneName = "CastleLevel"; // Name of the CastleLevel scene
    public Vector3 spawnPosition; // Specific location in CastleLevel scene
    public Vector3 spawnDirection; // Specific Direction in CastleLevel scene


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
    private void SaveSpawnPositionAndDirection()
    {
        PlayerPrefs.SetFloat("SpawnX", spawnPosition.x);
        PlayerPrefs.SetFloat("SpawnY", spawnPosition.y);
        PlayerPrefs.SetFloat("SpawnZ", spawnPosition.z);

        PlayerPrefs.SetFloat("SpawnDirX", spawnDirection.x);
        PlayerPrefs.SetFloat("SpawnDirZ", spawnDirection.z);
    }
}
