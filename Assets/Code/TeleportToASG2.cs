using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TeleportToASG2 : MonoBehaviour
{
    public string targetSceneName = "ASG2"; // Name of the ASG2 scene
    public Button teleportButton; // Reference to the UI button for teleportation

    public Vector3 spawnPosition; // Specific location in TempleLevel scene
    public Vector3 spawnDirection; // Specific Direction in ASG2 scene

    private void Start()
    {
        // Ensure the button is assigned in the inspector or via code
        if (teleportButton != null)
        {
            // Add listener to the button click event
            teleportButton.onClick.AddListener(TeleportPlayer);
        }
    }

    private void TeleportPlayer()
    {
        // Save the spawn position for ASG2 scene
        SaveSpawnPositionAndDirection();

        // Load ASG2 scene
        SceneManager.LoadScene(targetSceneName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Save the spawn position for TempleLevel scene
            PlayerPrefs.SetFloat("SpawnX", spawnPosition.x);
            PlayerPrefs.SetFloat("SpawnY", spawnPosition.y);
            PlayerPrefs.SetFloat("SpawnZ", spawnPosition.z);

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
