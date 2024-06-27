/*
 * Author: 
 * Date: 23 June 2024
 * Description: 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGun : MonoBehaviour
{
    public float damage;
    public float bulletRange;
    private Transform playerCamera;

    public GameObject bulletPrefab; // Reference to the bullet prefab
    public float bulletSpeed = 20f; // Speed of the bullet
    public float bulletLifetime = 3f; // Lifetime of the bullet in seconds
    public Transform bulletSpawnPoint; // Position where the bullet will spawn


    //particle system
    public ParticleSystem muzzle;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main.transform;
    }

    /// <summary>
    /// Uses raycast to find the enemy type then applies damage on hit
    /// </summary>
    public void Shoot()
    {
        muzzle.Play();
        // Create a ray starting from the player camera's position and going forward
        Ray gunRay = new Ray(playerCamera.position, playerCamera.forward);

        // Perform a raycast and check if it hits within bulletRange
        if (Physics.Raycast(gunRay, out RaycastHit hitInfo, bulletRange))
        {
            // Check if the hit object has an Entity component (enemy)
            if (hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))
            {

                Debug.Log(enemy.Health);
                // Apply damage to the enemy
                enemy.Health -= damage;

                // Destroy the bullet after hitting the enemy
                DestroyBullet();
            }
            else
            {
                // If the hit object is not an enemy, just destroy the bullet
                DestroyBullet();
            }
        }
        else
        {
            // If the raycast does not hit anything, just destroy the bullet
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        // Instantiate the bullet prefab at the bulletSpawnPoint position and rotation
        GameObject bulletObj = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Get the Rigidbody component of the bullet object
        Rigidbody rb = bulletObj.GetComponent<Rigidbody>();

        // Check if Rigidbody component exists (which it should if your bullet prefab has physics)
        if (rb != null)
        {
            // Apply forward force to the bullet to shoot straight
            rb.velocity = playerCamera.forward * bulletSpeed;
        }

        // Destroy the bullet after its lifetime expires
        Destroy(bulletObj, bulletLifetime);
    }
}
