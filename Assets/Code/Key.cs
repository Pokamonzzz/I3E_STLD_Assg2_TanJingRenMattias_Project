/*
 * Author: 
 * Date: 27 June 2024
 * Description: 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{
    //key to pick up to leave the ship

    public override void Interacted(Player player)
    {
        base.Interacted(player);
        Destroy(gameObject);
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
