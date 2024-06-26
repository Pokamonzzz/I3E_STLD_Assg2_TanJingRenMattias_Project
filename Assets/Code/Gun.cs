/*
 * Author: 
 * Date: 23 June 2024
 * Description: 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    public UnityEvent onGunShoot;
    public float fireCoolDown;

    // change the gun shooting either to semi or auto (deafult = auto)
    public bool automatic;

    private float currentCooldown;

    // Start is called before the first frame update
    void Start()
    {
        currentCooldown = fireCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (automatic)
        {
            if (Input.GetMouseButton(0))
            {
                if (currentCooldown <= 0f)
                {
                    onGunShoot?.Invoke();
                    currentCooldown = fireCoolDown;
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentCooldown <= 0f)
                {
                    onGunShoot?.Invoke();
                    currentCooldown = fireCoolDown;
                }
            }
        }
        currentCooldown -= Time.deltaTime;
    }
}
