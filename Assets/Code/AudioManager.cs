using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource Music;

    [SerializeField]
    AudioSource SFX;

    public static AudioManager instance;


    //create a public audioclip for each audio source i wan to use
    public AudioClip BGM;
    public AudioClip Gun;
    public AudioClip click;
    public AudioClip collect;

    private void Awake()
    {
        // Ensure only one instance of AudioManager exists
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

    public void Start()
    {
        Music.clip = BGM;
        Music.loop = true;
        Music.Play();
    }

    public void Effects(AudioClip Sfx)
    {
        SFX.PlayOneShot(Sfx);
    }

}
