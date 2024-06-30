using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crates : MonoBehaviour
{
    [SerializeField]
    private GameObject spawn; // The collectible prefab to spawn
    [SerializeField]
    private Transform spawnPoint; // The specific spawn point for the collectible
    [SerializeField]
    private GameObject winUI; // Reference to the UI element to show when the crystal spawns

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
