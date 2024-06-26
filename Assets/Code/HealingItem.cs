/*
 * Author: 
 * Date: 23 June 2024
 * Description: 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    public float healAmount = 5f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called with: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player tag detected.");
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.HealPlayer(healAmount);
                Debug.Log("Healing player. Current health: " + player.currentHealth);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("Player component not found on the Player.");
            }
        }
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
