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

    private void Start()
    {
        playerSpawner = FindObjectOfType<PlayerSpawner>();
        if (playerSpawner == null)
        {
            Debug.LogWarning("Player spawner not found.");
        }
        if (SceneManager.GetActiveScene().name == "StartMenu" && AudioManager.instance != null)
        {
            AudioManager.instance.Start();
        }
    }

    public void ChangeScene(int sceneIndex)
    {
        if (SceneManager.GetActiveScene().name == "StartMenu" && canvasToPersist != null)
        {
            GameManager.instance.SetPersistentCanvas(canvasToPersist);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneIndex);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        if (scene.name == "ASG2" && canvasToPersist != null)
        {
            GameManager.instance.SetPersistentCanvas(canvasToPersist);
        }
        GameManager.instance.DestroyOnScene("StartMenu");
        if (scene.name == "ASG2")
        {
            Player player = FindObjectOfType<Player>();
            if (player != null)
            {
                player.InitializePlayer();
            }
        }
    }

    public void PauseMenu()
    {
        if (!isPaused)
        {
            pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            isPaused = true;
            Time.timeScale = 0;
            // Play click sound effect
            if (AudioManager.instance != null)
            {
                AudioManager.instance.Effects(AudioManager.instance.click);
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            pauseMenu.SetActive(false);
            isPaused = false;
            Time.timeScale = 1;
            // Play click sound effect
            if (AudioManager.instance != null)
            {
                AudioManager.instance.Effects(AudioManager.instance.click);
            }
        }
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu?.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
        // Play click sound effect
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Effects(AudioManager.instance.click);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Cursor.lockState= CursorLockMode.Locked;
        pauseMenu?.SetActive(false);
        Time.timeScale = 1;
        player.InitializePlayer();
        player.Die();

        // Play click sound effect
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Effects(AudioManager.instance.click);
        }
    }

    public void Home()
    {
        GameManager.instance.ClearPersistentCanvas();
        SceneManager.LoadScene("StartMenu");
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
        // Play click sound effect
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Effects(AudioManager.instance.click);
        }
        MenuDestroy();
    }

    public void Setting()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.Effects(AudioManager.instance.click);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MenuDestroy()
    {
        Destroy(gameObject);
    }

    void Update()
    {

    }
}
