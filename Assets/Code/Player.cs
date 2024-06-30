/*
 * Author: Tan Jing Ren Mattias
 * Date: 23 June 2024
 * Description: Controls player health, interaction, and game over functionality
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
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100f;
    public HealthBar healthBar;
    public float currentHealth;

    /// <summary>
    /// The current Interactable object the player can interact with.
    /// </summary>
    Interactable currentInteractable;

    [SerializeField] Transform playerCamera;
    [SerializeField] float interactionDistance;
    [SerializeField] TextMeshProUGUI interactionText;
    [SerializeField] Transform respawnPoint;
    [SerializeField] Transform player;
    [SerializeField] Canvas gameOverCanvas; // Reference to the Game Over Canvas
    [SerializeField] Button restartButton; // Reference to the Restart Button
    [SerializeField] Button quitButton; // Reference to the Quit Button

    public Menu menu;

    private static Player instance;

    /// <summary>
    /// Don tdestroy the player
    /// </summary>
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(interactionText.gameObject); // Ensure interaction text is not destroyed
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
                return;
            }
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetSliderMax(maxHealth);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
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

        // Raycast to detect interactable objects
        Debug.DrawLine(playerCamera.position, playerCamera.position + (playerCamera.forward * interactionDistance), Color.red);
        RaycastHit hitInfo;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hitInfo, interactionDistance))
        {
            if (hitInfo.transform.TryGetComponent<Interactable>(out currentInteractable))
            {
                // Display interaction text
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

        // Handle interaction input
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnInteract();
        }

        // Handle pause input
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPause();
        }
    }

    /// <summary>
    /// Called when player interacts with an interactable object.
    /// </summary>
    private void OnInteract()
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interacted(this);
        }
    }

    /// <summary>
    /// Opens the pause menu.
    /// </summary>
    private void OnPause()
    {
        menu.PauseMenu();
    }

    /// <summary>
    /// Initializes the player state.
    /// </summary>
    public void InitializePlayer()
    {
        currentHealth = maxHealth; // Reset health to maximum
        healthBar.SetSlider(currentHealth); // Update health UI
        Debug.Log("Player initialized.");
    }

    /// <summary>
    /// Applies damage to the player.
    /// </summary>
    /// <param name="amount">Amount of damage to apply.</param>
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthBar.SetSlider(currentHealth);
    }

    /// <summary>
    /// Heals the player.
    /// </summary>
    /// <param name="amount">Amount of health to restore.</param>
    public void HealPlayer(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Clamp health to ensure it doesn't exceed maxHealth
        healthBar.SetSlider(currentHealth);
    }

    /// <summary>
    /// Handles player death.
    /// </summary>
    public void Die()
    {
        Debug.Log("Player has died.");
        player.transform.position = respawnPoint.transform.position; // Respawn player at respawn point
        gameOverCanvas.gameObject.SetActive(true); // Activate game over canvas
    }

    /// <summary>
    /// Handles trigger collisions.
    /// </summary>
    /// <param name="collision">Collider involved in the collision.</param>
    private void OnTriggerEnter(Collider collision)
    {
        // Change scene based on trigger tags
        if (collision.tag == "ASG2")
        {
            SceneManager.LoadScene(1); // Load ASG2 scene
        }
        else if (collision.tag == "TempleLevel")
        {
            SceneManager.LoadScene(0); // Load TempleLevel scene
        }
    }
}