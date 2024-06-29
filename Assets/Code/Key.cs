/*
 * Author: 
 * Date: 27 June 2024
 * Description: 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Key : Interactable
{
    //key to pick up to leave the ship
    public Door spaceDoor;
    public Door bridgeDoor;

    public override void Interacted(Player player)
    {
        base.Interacted(player);

        // Notify the GameManager that the key is collected
        GameManager.instance.CollectKey();

        // unlock and destory door if it exist
        if (spaceDoor != null)
        {
            Debug.Log("Key collected. Attempting to open the door.");
            spaceDoor.Setlock(false);
            spaceDoor.OpenDoor();
        }

        if (bridgeDoor != null)
        {
            Debug.Log("Key collected. Attempting to unlock and open the bridge door.");
            bridgeDoor.Setlock(false);
            bridgeDoor.OpenDoor();
        }
        Destroy(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        //lock the door
        if (spaceDoor != null)
        {
            spaceDoor.Setlock(true);
        }

        if (bridgeDoor != null)
        {
            bridgeDoor.Setlock(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
