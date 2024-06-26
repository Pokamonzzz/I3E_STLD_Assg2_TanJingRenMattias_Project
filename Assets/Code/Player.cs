using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    public HealthBar healthBar;

    public float currentHealth;

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
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(20f);
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
