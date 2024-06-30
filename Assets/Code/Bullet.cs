/*
 * Author: Tan Jing Ren Mattias
 * Date: 23 June 2024
 * Description: The bullet that deals damage, kill and destory objects in game
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the behavior of a bullet in the game.
/// </summary>
public class Bullet : MonoBehaviour
{
    /// <summary>
    /// The amount of damage the bullet will inflict.
    /// </summary>
    public float damage;

    /// <summary>
    ///  setting bullet to be destroyed after a set time.
    /// </summary>
    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    /// <summary>
    /// Handles collisions with other game objects.
    /// </summary>
    /// <param name="other">The collider of the object the bullet collides with.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Crate"))
        {
            Destroy(gameObject); // Destroy bullet on collision with crate
        }
    }
}