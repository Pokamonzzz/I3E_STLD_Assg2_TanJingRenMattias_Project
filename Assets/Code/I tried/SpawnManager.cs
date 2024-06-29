using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    // List of predefined spawn points
    public Transform[] spawnPointsASG2; // For ASG2 scene
    public Transform[] spawnPointsTempleLevel; // For TempleLevel scene

    // Store the index of the spawn point to use
    private int spawnIndexASG2 = 0; // Default spawn index for ASG2
    private int spawnIndexTempleLevel = 0; // Default spawn index for TempleLevel

    private void Awake()
    {
        //  to ensure only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Determine current scene and spawn player accordingly
        if (scene.name == "ASG2")
        {
            SpawnPlayerAtASG2SpawnPoint();
        }
        else if (scene.name == "TempleLevel")
        {
            SpawnPlayerAtTempleLevelSpawnPoint();
        }
        else
        {
            Debug.LogWarning($"Unhandled scene: {scene.name}");
        }
    }
    private void LoadTempleLevelSpawnPoints()
    {
        GameObject[] spawnPointObjects = GameObject.FindGameObjectsWithTag("SpawnPointTempleLevel");
        spawnPointsTempleLevel = new Transform[spawnPointObjects.Length];
        for (int i = 0; i < spawnPointObjects.Length; i++)
        {
            spawnPointsTempleLevel[i] = spawnPointObjects[i].transform;
        }
    }

    // Set the spawn index for ASG2 scene
    public void SetSpawnIndexASG2(int index)
    {
        spawnIndexASG2 = index;
    }

    // Set the spawn index for TempleLevel scene
    public void SetSpawnIndexTempleLevel(int index)
    {
        spawnIndexTempleLevel = index;
    }

    // Spawn player at the specified index for ASG2 scene
    public void SpawnPlayerAtASG2SpawnPoint()
    {
        if (spawnPointsASG2 != null && spawnPointsASG2.Length > 0)
        {
            if (spawnIndexASG2 < spawnPointsASG2.Length)
            {
                Transform spawnPoint = spawnPointsASG2[spawnIndexASG2];
                Player player = FindObjectOfType<Player>(); // Adjust this based on your player setup
                if (player != null)
                {
                    player.transform.position = spawnPoint.position;
                    player.transform.rotation = spawnPoint.rotation;
                    Debug.Log($"Spawned player at: {spawnPoint.name} in ASG2 scene.");
                }
                else
                {
                    Debug.LogWarning("Player not found for spawning.");
                }
            }
            else
            {
                Debug.LogWarning($"Invalid spawn index {spawnIndexASG2} for ASG2 scene.");
            }
        }
        else
        {
            Debug.LogWarning("No spawn points defined for ASG2 scene.");
        }
    }

    // Spawn player at the specified index for TempleLevel scene
    public void SpawnPlayerAtTempleLevelSpawnPoint()
    {
        if (spawnPointsTempleLevel != null && spawnPointsTempleLevel.Length > 0)
        {
            if (spawnIndexTempleLevel < spawnPointsTempleLevel.Length)
            {
                Transform spawnPoint = spawnPointsTempleLevel[spawnIndexTempleLevel];
                Player player = FindObjectOfType<Player>(); // Adjust this based on your player setup
                if (player != null)
                {
                    player.transform.position = spawnPoint.position;
                    player.transform.rotation = spawnPoint.rotation;
                    Debug.Log($"Spawned player at: {spawnPoint.name} in TempleLevel scene.");
                }
                else
                {
                    Debug.LogWarning("Player not found for spawning.");
                }
            }
            else
            {
                Debug.LogWarning($"Invalid spawn index {spawnIndexTempleLevel} for TempleLevel scene.");
            }
        }
        else
        {
            Debug.LogWarning("No spawn points defined for TempleLevel scene.");
        }
    }
}
