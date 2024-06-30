/*
 * Author:Tan Jing Ren Mattias 
 * Date: 28 June 2024
 * Description: Manages the game state including key collection, persistence across scenes, and destruction upon entering certain scenes.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Singleton instance of the GameManager.
    /// </summary>
    public static GameManager instance;

    /// <summary>
    /// Reference to the Canvas in the scene to persist across scene loads.
    /// </summary>
    public Canvas persistentCanvas;

    /// <summary>
    /// Static reference to the SpawnManager.
    /// </summary>
    public static SpawnManager spawnManager;

    /// <summary>
    /// Stores the state of collected keys.
    /// </summary>
    private bool hasKey = false;

    /// <summary>
    /// Ensures only one instance of GameManager exists and persists across scene loads.
    /// </summary>
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    /// <summary>
    /// Sets the persistent Canvas and ensures it persists across scene loads.
    /// </summary>
    /// <param name="canvas">The Canvas to persist.</param>
    public void SetPersistentCanvas(Canvas canvas)
    {
        if (persistentCanvas == null)
        {
            persistentCanvas = canvas;
            DontDestroyOnLoad(persistentCanvas.gameObject);
        }
    }

    /// <summary>
    /// Clears the persistent Canvas.
    /// </summary>
    public void ClearPersistentCanvas()
    {
        if (persistentCanvas != null)
        {
            Destroy(persistentCanvas.gameObject);
            persistentCanvas = null;
        }
    }

    /// <summary>
    /// Destroys the GameManager instance when entering a specific scene.
    /// </summary>
    /// <param name="sceneName">The name of the scene in which to destroy the GameManager.</param>
    public void DestroyOnScene(string sceneName)
    {
        if (SceneManager.GetActiveScene().name == sceneName)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Method to collect a key.
    /// </summary>
    public void CollectKey()
    {
        hasKey = true;
        Debug.Log("Key collected.");
    }

    /// <summary>
    /// Method to check if the key is collected.
    /// </summary>
    /// <returns>True if the key is collected, otherwise false.</returns>
    public bool HasKey()
    {
        return hasKey;
    }
}
