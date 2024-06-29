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

    [SerializeField]
    Transform playerCamera;

    [SerializeField]
    float interactionDistance;

    [SerializeField]
    TextMeshProUGUI interactionText;

    public Menu menu;

    private static bool playerExists;

    private void Awake()
    {
        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(this.gameObject);
            DontDestroyOnLoad(interactionText.gameObject); // Ensure interaction text is not destroyed
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetSliderMax(maxHealth);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

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

        // Raycast for player
        Debug.DrawLine(playerCamera.position, playerCamera.position + (playerCamera.forward * interactionDistance), Color.red);
        RaycastHit hitInfo;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hitInfo, interactionDistance))
        {
            // print out the name of whatever my ray hit
            if (hitInfo.transform.TryGetComponent<Interactable>(out currentInteractable))
            {
                //Display some interation text
                interactionText.gameObject.SetActive(true);
            }
            else
            {
                currentInteractable = null;
                interactionText.gameObject.SetActive(false);
            }
        }
        else
        {
            currentInteractable = null;
            interactionText.gameObject.SetActive(false);
        }
    }

    void OnInteract()
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interacted(this);
        }
    }
    void OnPause()
    {
        menu.PauseMenu();
    }

    public void InitializePlayer()
    {
        currentHealth = maxHealth; // Reset health to maximum
        healthBar.SetSlider(currentHealth); // Update health UI
        Debug.Log("everything resetted");
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
