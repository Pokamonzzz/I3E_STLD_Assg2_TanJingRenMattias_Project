/*
 * Author: Tan Jing Ren Mattias
 * Date: 27 June 2024
 * Description: Manages the Door locking system and destory itself  
 */using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Door : MonoBehaviour
{
    /// <summary>
    /// Indicates whether the door is locked.
    /// </summary>
    bool locked = false;

    /// <summary>
    /// Opens the door if it is not locked, destroying the door game object.
    /// </summary>
    public void OpenDoor()
    {
        // locked so that doors that does not need key cards can still open
        if (!locked)
        {
            // make the door dissapear
            Debug.Log("Door is being opened and destroyed.");
            Destroy(gameObject);
            Debug.Log("no");
        }

    }

    /// <summary>
    /// Sets the lock status of the door.
    /// </summary>
    /// <param name="lockedStatus">The new lock status.</param>
    public void Setlock(bool lockedStatus)
    {
        locked = lockedStatus;
        Debug.Log("Door lock status set to: " + locked);
    }
}