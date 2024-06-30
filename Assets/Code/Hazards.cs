/*
 * Author: Tan Jing Ren Mattias
 * Date: 27 June 2024
 * Description: Manages hazards that cause damage to the player on collision or trigger enter/exit.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : MonoBehaviour
{
    /// <summary>
    /// Damage inflicted on initial collision.
    /// </summary>
    public float initialDamage = 10f;

    /// <summary>
    /// Continuous damage per second while player is in contact.
    /// </summary>
    public float continuousDamage = 5f;

    /// <summary>
    /// Interval between each instance of continuous damage.
    /// </summary>
    public float damageInterval = 1f;

    /// <summary>
    /// Timer for continuous damage intervals.
    /// </summary>
    private float damageTimer;

    /// <summary>
    /// Handles collision events with the player.
    /// </summary>
    /// <param name="collision">The collision data.</param>
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
    /// Handles continuous collision events with the player.
    /// </summary>
    /// <param name="collision">The collision data.</param>
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
    /// Handles trigger events when the player enters the hazard area.
    /// </summary>
    /// <param name="other">The collider of the other object.</param>
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
    /// Handles continuous trigger events while the player is in the hazard area.
    /// </summary>
    /// <param name="other">The collider of the other object.</param>
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
}