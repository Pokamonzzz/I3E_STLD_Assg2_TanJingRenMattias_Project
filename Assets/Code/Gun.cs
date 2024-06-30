/*
 * Author: Tan Jing Ren Mattias
 * Date: 23 June 2024
 * Description: Manages gun shooting mechanics, including semi-automatic and automatic firing modes, cooldown management, and sound effects.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    /// <summary>
    /// Event invoked when the gun shoots.
    /// </summary>
    public UnityEvent onGunShoot;

    /// <summary>
    /// Cooldown time between shots.
    /// </summary>
    public float fireCoolDown;

    /// <summary>
    /// Determines if the gun is automatic. Default is automatic.
    /// </summary>
    public bool automatic;

    /// <summary>
    /// Current cooldown time.
    /// </summary>
    private float currentCooldown;

    /// <summary>
    /// Reference to the AudioManager for playing sound effects.
    /// </summary>
    public AudioManager audioManager;

    /// <summary>
    /// Initializes the gun's cooldown time.
    /// </summary>
    void Start()
    {
        currentCooldown = fireCoolDown;
    }

    /// <summary>
    /// Finds the AudioManager in the scene.
    /// </summary>
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    /// <summary>
    /// Plays the gun shot sound effect.
    /// </summary>
    public void Sound()
    {
        if (audioManager != null && audioManager.Gun != null)
        {
            audioManager.Effects(audioManager.Gun);
        }
    }

    /// <summary>
    /// Handles the gun shooting mechanics based on the firing mode.
    /// </summary>
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
                    audioManager.Effects(audioManager.Gun);
                    currentCooldown = fireCoolDown;
                }
            }
        }
        currentCooldown -= Time.deltaTime;
    }
}