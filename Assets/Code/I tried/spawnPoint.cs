using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private void Start()
    {
        // Check if this is the spawn point intended for this scene
        if (gameObject.name == PlayerPrefs.GetString("SpawnPointName"))
        {
            SpawnPlayer();
        }
    }

    private void SpawnPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = transform.position;
            player.transform.rotation = transform.rotation;
            Debug.Log($"Player spawned at: {gameObject.name}");
        }
        else
        {
            Debug.LogWarning("Player object not found to spawn.");
        }
    }
}
