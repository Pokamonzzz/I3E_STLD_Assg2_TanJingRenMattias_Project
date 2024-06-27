/*
 * Author: 
 * Date: 23 June 2024
 * Description: 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100f;

    public HealthBar healthBar;

    public float currentHealth;

    /// <summary>
    /// The current Interactable of the player
    /// </summary>
    Interactable currentInteractable;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetSliderMax(maxHealth);
    }
    private void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Amount of damage taken when hit
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthBar.SetSlider(currentHealth);
    }

    /// <summary>
    /// Amount of health to heal the player
    /// </summary>
    /// <param name="amount"></param>
    public void HealPlayer(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Clamp health to ensure it doesn't exceed maxHealth
        healthBar.SetSlider(currentHealth);
    }

    /// <summary>
    /// u die lor
    /// </summary>
    private void Die()
    {
        Debug.Log("you died");
    }
}
