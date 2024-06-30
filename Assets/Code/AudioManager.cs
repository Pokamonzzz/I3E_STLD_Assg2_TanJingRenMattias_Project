/*
 * Author: Tan Jing Ren Mattias
 * Date: 27 June 2024
 * Description: Audio Manager for all the game sound
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// Audio scource for Bg music
    /// </summary>
    [SerializeField]
    AudioSource Music;

    /// <summary>
    /// Audio source for effects
    /// </summary>
    [SerializeField]
    AudioSource SFX;

    /// <summary>
    /// Instance of AudioManager
    /// </summary>
    public static AudioManager instance;


    //create a public audioclip for each audio source i wan to use
    /// <summary>
    /// Audio clip for Background music
    /// </summary>
    public AudioClip BGM;

    /// <summary>
    /// Audio clip for Gun sound effect
    /// </summary>
    public AudioClip Gun;

    /// <summary>
    /// Audio clip for click sound effect
    /// </summary>
    public AudioClip click;

    /// <summary>
    /// Audio clip for Collect
    /// </summary>
    public AudioClip collect;

    /// <summary>
    /// Ensures only one instance of AudioManager exists.
    /// </summary>
    private void Awake()
    {
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

    /// <summary>
    /// Starts playing the background music on a loop.
    /// </summary>
    public void Start()
    {
        Music.clip = BGM;
        Music.loop = true;
        Music.Play();
    }

    /// <summary>
    /// Plays a given sound effect.
    /// </summary>
    /// <param name="Sfx"> The audio clip to play as a sound effect</param>
    public void Effects(AudioClip Sfx)
    {
        SFX.PlayOneShot(Sfx);
    }

}
