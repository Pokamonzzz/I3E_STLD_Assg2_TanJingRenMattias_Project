/*
 * Author: 
 * Date: 23 June 2024
 * Description: 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour
{
    [SerializeField]
    private float startingHealth;
    public float health;

    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;

            if (health <0f)
            {
                Destroy(gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Health = startingHealth;
    }
}
