/*
 * Author: 
 * Date: 28 June 2024
 * Description: 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // to only have 1 game manager
    public static GameManager instance;
    // Reference to the Canvas in the scene to not get destroyed
    public Canvas persistentCanvas;
    public static SpawnManager spawnManager;


    // Store the state of collected keys
    private bool hasKey = false;

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

    public void SetPersistentCanvas(Canvas canvas)
    {
        if (persistentCanvas == null)
        {
            persistentCanvas = canvas;
            DontDestroyOnLoad(persistentCanvas.gameObject);
        }
    }

    public void ClearPersistentCanvas()
    {
        if (persistentCanvas != null)
        {
            Destroy(persistentCanvas.gameObject);
            persistentCanvas = null;
        }
    }
    public void DestroyOnScene(string sceneName)
    {
        if (SceneManager.GetActiveScene().name == sceneName)
        {
            Destroy(gameObject);
        }
    }

    // Method to collect a key
    public void CollectKey()
    {
        hasKey = true;
        Debug.Log("Key collected.");
    }

    // Method to check if the key is collected
    public bool HasKey()
    {
        return hasKey;
    }
}
