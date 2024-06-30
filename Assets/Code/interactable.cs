/*
 * Author: 
 * Date: 27 June 2024
 * Description: 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interacted(Player player)
    {
        Debug.Log($"{gameObject.name} interacted by {player.gameObject.name}");
        AudioManager.instance?.Effects(AudioManager.instance.collect);
    }

}
