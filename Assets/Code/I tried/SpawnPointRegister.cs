/*
 * Author: 
 * Date: 23 June 2024
 * Description: 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPointRegister : MonoBehaviour
{
    public int spawnPointIndex;
    public string sceneName;

  //private void Awake()
  //{
  //    if (SpawnManager.instance != null)
  //    {
  //        Transform[] currentSpawnPoints = GetCurrentSpawnPoints(sceneName);
  //        if (currentSpawnPoints != null && spawnPointIndex >= 0 && spawnPointIndex < currentSpawnPoints.Length)
  //        {
  //            currentSpawnPoints[spawnPointIndex] = transform;
  //        }
  //        else
  //        {
  //            Debug.LogWarning($"Spawn point index {spawnPointIndex} is out of range for the current scene.");
  //        }
  //    }
  //    else
  //    {
  //        Debug.LogWarning("SpawnManager instance not found.");
  //    }
  //}

  //private Transform[] GetCurrentSpawnPoints(string sceneName)
  //{
  //    if (sceneName == "ASG2")
  //    {
  //        return SpawnManager.instance.spawnPointsASG2;
  //    }
  //    else if (sceneName == "TempleLevel")
  //    {
  //        //return SpawnManager.instance.spawnPointsTempleLevel;
  //    }
  //    else
  //    {
  //        Debug.LogWarning($"Unhandled scene: {sceneName}");
  //        return null;
  //    }
  //}
}