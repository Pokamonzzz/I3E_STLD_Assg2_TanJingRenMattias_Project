using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource Music;

    [SerializeField]
    AudioSource SFX;

    //create a public audioclip for each audio source i wan to use
    public AudioClip Gun;

    public void BackGroundMusic(AudioClip bgm)
    {
        Music.clip = bgm;
        Music.loop = true;
        Music.Play();
    }

    public void Effects(AudioClip Sfx)
    {
        SFX.PlayOneShot(Sfx);
    }

}
