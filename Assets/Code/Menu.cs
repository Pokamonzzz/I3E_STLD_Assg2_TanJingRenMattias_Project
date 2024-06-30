/*
 * Author: Tan Jing Ren Mattias
 * Date: 29 June 2024
 * Description: Handles menu functionalities such as pausing, resuming, changing scenes, and quitting the game.
 */
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused = false;

    public Canvas canvasToPersist;

    private PlayerSpawner playerSpawner;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        playerSpawner = FindObjectOfType<PlayerSpawner>();
        if (playerSpawner == null)
        {
            Debug.LogWarning("Player spawner not found.");
        }

        // Handle AudioManager initialization in StartMenu scene
        if (SceneManager.GetActiveScene().name == "StartMenu" && AudioManager.instance != null)
        {
            AudioManager.instance.Start();
        }
    }

    /// <summary>
    /// Changes the scene to the specified scene index.
    /// </summary>
    /// <param name="sceneIndex">Index of the scene to change to.</param>
    public void ChangeScene(int sceneIndex)
    {
        // Persist canvas in StartMenu and ASG2 scenes
        if (SceneManager.GetActiveScene().name == "StartMenu" && canvasToPersist != null)
        {
            GameManager.instance.SetPersistentCanvas(canvasToPersist);
        }

        // Load the scene with the given index
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneIndex);
    }

    /// <summary>
    /// Callback method invoked when a scene is loaded.
    /// </summary>
    /// <param name="scene">Loaded scene.</param>
    /// <param name="mode">LoadSceneMode.</param>
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // Persist canvas in ASG2 scene
        if (scene.name == "ASG2" && canvasToPersist != null)
        {
            GameManager.instance.SetPersistentCanvas(canvasToPersist);
        }

        // Destroy GameManager in StartMenu scene
        GameManager.instance.DestroyOnScene("StartMenu");

        // Initialize player if found in ASG2 scene
        if (scene.name == "ASG2")
        {
            Player player = FindObjectOfType<Player>();
            if (player != null)
            {
                player.InitializePlayer();
            }
        }
    }

    /// <summary>
    /// Activates or deactivates the pause menu.
    /// </summary>
    public void PauseMenu()
    {
        if (!isPaused)
        {
            // Pause the game
            pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            isPaused = true;
            Time.timeScale = 0;

            // Play click sound effect
            AudioManager.instance?.Effects(AudioManager.instance.click);
        }
        else
        {
            // Resume the game
            Cursor.lockState = CursorLockMode.Locked;
            pauseMenu.SetActive(false);
            isPaused = false;
            Time.timeScale = 1;

            // Play click sound effect
            AudioManager.instance?.Effects(AudioManager.instance.click);
        }
    }

    /// <summary>
    /// Resumes the game from pause state.
    /// </summary>
    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu?.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;

        // Play click sound effect
        AudioManager.instance?.Effects(AudioManager.instance.click);
    }

    /// <summary>
    /// Restarts the current scene.
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu?.SetActive(false);
        Time.timeScale = 1;

        // Initialize and handle player respawn if needed
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            player.InitializePlayer();
            player.Die(); // Example method call for player respawn handling
        }

        // Play click sound effect
        AudioManager.instance?.Effects(AudioManager.instance.click);
    }

    /// <summary>
    /// Returns to the StartMenu scene and clears persistent canvas.
    /// </summary>
    public void Home()
    {
        GameManager.instance.ClearPersistentCanvas();
        SceneManager.LoadScene("StartMenu");
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;

        // Play click sound effect
        AudioManager.instance?.Effects(AudioManager.instance.click);

        MenuDestroy();
    }

    /// <summary>
    /// Placeholder method for handling settings menu.
    /// </summary>
    public void Setting()
    {
        // Placeholder for setting menu functionality

        // Play click sound effect
        AudioManager.instance?.Effects(AudioManager.instance.click);
    }

    /// <summary>
    /// Quits the game.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Destroys the menu object.
    /// </summary>
    public void MenuDestroy()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
