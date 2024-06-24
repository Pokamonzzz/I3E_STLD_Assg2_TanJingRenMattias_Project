using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGun : MonoBehaviour
{
    public float damage;
    public float bulletRange;
    private Transform playerCamera;


    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main.transform;
    }

    /// <summary>
    /// uses raycast to find the enemy type then minus the health from damage taken
    /// </summary>
    public void shoot()
    {
        Ray gunRay = new Ray(playerCamera.position, playerCamera.forward);
        if (Physics.Raycast(gunRay, out RaycastHit hitInfo, bulletRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))
            {
                enemy.Health -= damage;
            }
        }
    }
}
