/*
 * Author: 
 * Date: 27 June 2024
 * Description: Manages the health of an entity, including initialization and destruction upon death.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour
{
    /// <summary>
    /// The initial health value for the entity.
    /// </summary>
    [SerializeField]
    private float startingHealth;

    /// <summary>
    /// The current health of the entity.
    /// </summary>
    public float health;

    /// <summary>
    /// Gets or sets the health of the entity. Destroys the entity if health drops below zero.
    /// </summary>
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;

            if (health < 0f)
            {
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// Initializes the entity's health to the starting value.
    /// </summary>
    void Start()
    {
        Health = startingHealth;
    }
}
