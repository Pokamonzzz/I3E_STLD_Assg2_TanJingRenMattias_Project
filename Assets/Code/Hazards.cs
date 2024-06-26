/*
 * Author: 
 * Date: 27 June 2024
 * Description: 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : MonoBehaviour
{   
    // Damage on initial collision
    public float initialDamage = 10f;

    // Continuous damage per second
    public float continuousDamage = 5f; 

    // Damage interval in seconds
    public float damageInterval = 1f; 
    
    // Timer for continuous damage
    private float damageTimer; 

    /// <summary>
    /// Collision with the player
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Apply initial damage on collision enter
            collision.gameObject.GetComponent<Player>().TakeDamage(initialDamage);

            // Start continuous damage timer
            damageTimer = damageInterval;
        }
    }

    /// <summary>
    /// Collision with the player like hitting a fence
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Continuously apply damage while player stays in contact
            damageTimer -= Time.deltaTime;
            if (damageTimer <= 0)
            {
                collision.gameObject.GetComponent<Player>().TakeDamage(continuousDamage);
                damageTimer = damageInterval; // Reset the timer
            }
        }
    }
    /// <summary>
    /// when in lava u need to be in so ontriggerEnter
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Apply initial damage when player enters trigger
            other.GetComponent<Player>().TakeDamage(initialDamage);

            // Start continuous damage timer
            damageTimer = damageInterval;
        }
    }
    /// <summary>
    /// Same thing like in lava
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Continuously apply damage while player stays in trigger area
            damageTimer -= Time.deltaTime;
            if (damageTimer <= 0)
            {
                other.GetComponent<Player>().TakeDamage(continuousDamage);
                damageTimer = damageInterval; // Reset the timer
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
