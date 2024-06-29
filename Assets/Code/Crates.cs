using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crates : MonoBehaviour
{
    [SerializeField]
    private GameObject spawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            SpawnCollectible();
            Destroy(gameObject);
        }
    }

    void SpawnCollectible()
    {
        Instantiate(spawn, transform.position, spawn.transform.rotation);
    }
}
