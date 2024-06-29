/*
 * Author: 
 * Date: 23 June 2024
 * Description: 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    private void Start()
    {
        Destroy(gameObject, 10f);
    }
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