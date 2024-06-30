using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportWithinScene : MonoBehaviour
{
    public Transform player, destination;
    public GameObject playerg;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerg.SetActive(false);
            player.position = destination.position;
            playerg.SetActive(true);
        }
    }
    private void Start()
    {
        // Ensure player and player game object are not destroyed on scene load
        if (player != null)
        {
            DontDestroyOnLoad(player.gameObject);
        }
        if (playerg != null)
        {
            DontDestroyOnLoad(playerg);
        }
    }
}


