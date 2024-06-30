/*
 * Author: Tan Jing Ren Mattias
 * Date: 30 June 2024
 * Description: Handles teleportation functionality and saves spawn positions.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TeleportToASG2 : MonoBehaviour
{
    /// <summary>
    /// Name of the target scene to teleport to (default: "ASG2").
    /// </summary>
    public string targetSceneName = "ASG2";

    /// <summary>
    /// Reference to the UI button used for teleportation.
    /// </summary>
    public Button teleportButton;

    /// <summary>
    /// Specific spawn position in the ASG2 scene.
    /// </summary>
    public Vector3 spawnPosition;

    /// <summary>
    /// Specific spawn direction in the ASG2 scene.
    /// </summary>
    public Vector3 spawnDirection;

    private void Start()
    {
        // Ensure the button is assigned in the inspector or via code
        if (teleportButton != null)
        {
            // Add listener to the button click event
            teleportButton.onClick.AddListener(TeleportPlayer);
        }
    }

    /// <summary>
    /// Teleports the player to the ASG2 scene.
    /// </summary>
    private void TeleportPlayer()
    {
        // Save the spawn position and direction for ASG2 scene
        SaveSpawnPositionAndDirection();

        // Load ASG2 scene
        SceneManager.LoadScene(targetSceneName);
    }

    /// <summary>
    /// Saves the spawn position and direction for the TempleLevel scene when the player enters the trigger.
    /// </summary>
    /// <param name="other">The collider triggering the event.</param>
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

    /// <summary>
    /// Saves the spawn position and direction for the ASG2 scene.
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
