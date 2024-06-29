using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField]
    private AudioMixer myMixer;
    [SerializeField]
    private Slider masterSlider;
    [SerializeField]
    private Slider musicSlider;
    [SerializeField]
    private Slider sFXSlider;
    [SerializeField]
    private Toggle muteButton;

    bool isMuted = false;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
        //call the function
        SetMusicVolume();
        SetSFXVolume();
        SetMasterVolume();
        }


        if (muteButton != null)
        {
            muteButton.onValueChanged.AddListener(ToggleMute);
        }
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }


    public void SetSFXVolume()
    {
        float volume = sFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sFXVolume", volume);
    }

    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        myMixer.SetFloat("master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }
    public void ToggleMute(bool isMuted)
    {
        this.isMuted = !isMuted;

        if (isMuted)
        {
            // Mute all volumes
            myMixer.SetFloat("Music", -80f); // -80 dB is effectively muted
            myMixer.SetFloat("SFX", -80f);
            myMixer.SetFloat("master", -80f);
        }
        else
        {
            // Unmute (set volumes back to slider values)
            SetMusicVolume();
            SetSFXVolume();
            SetMasterVolume();
        }
    }
    void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        musicSlider.value = PlayerPrefs.GetFloat("sFXVolume");
        musicSlider.value = PlayerPrefs.GetFloat("masterVolume");

        SetMusicVolume();
        SetSFXVolume();
        SetMasterVolume();
    }
}
