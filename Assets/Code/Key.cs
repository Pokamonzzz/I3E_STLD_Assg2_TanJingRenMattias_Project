/*
 * Author: Tan Jing Ren Mattias
 * Date: 27 June 2024
 * Description: 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Key : Interactable
{
    /// <summary>
    /// Reference to the space door that this key unlocks.
    /// </summary>
    public Door spaceDoor;

    /// <summary>
    /// Reference to the bridge door that this key unlocks.
    /// </summary>
    public Door bridgeDoor;

    /// <summary>
    /// Called when the key is interacted with by the player.
    /// </summary>
    /// <param name="player">The player interacting with the key.</param>
    public override void Interacted(Player player)
    {
        base.Interacted(player);

        // Notify the GameManager that the key is collected
        GameManager.instance.CollectKey();

        // Unlock and destroy space door if it exists
        if (spaceDoor != null)
        {
            Debug.Log("Key collected. Attempting to open the space door.");
            spaceDoor.Setlock(false);
            spaceDoor.OpenDoor();
        }

        // Unlock and destroy bridge door if it exists
        if (bridgeDoor != null)
        {
            Debug.Log("Key collected. Attempting to unlock and open the bridge door.");
            bridgeDoor.Setlock(false);
            bridgeDoor.OpenDoor();
        }

        // Destroy the key object after interaction
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Lock the space door initially if it exists
        if (spaceDoor != null)
        {
            spaceDoor.Setlock(true);
        }

        // Lock the bridge door initially if it exists
        if (bridgeDoor != null)
        {
            bridgeDoor.Setlock(true);
        }
    }
}