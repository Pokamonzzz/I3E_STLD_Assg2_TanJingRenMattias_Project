/*
 * Author: 
 * Date: 
 * Description: 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
