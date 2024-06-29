/*
 * Author: 
 * Date: 27 June 2024
 * Description: 
 */using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Door : MonoBehaviour
{

    bool locked = false;

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

    public void Setlock(bool lockedStatus)
    {
        locked = lockedStatus;
        Debug.Log("Door lock status set to: " + locked);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
