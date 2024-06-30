/*
 * Author: Tan Jing Ren Mattias
 * Date: 30 June 2024
 * Description: Manages audio settings including master, music, and SFX volumes.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    /// <summary>
    /// Reference to the AudioMixer controlling audio levels.
    /// </summary>
    [SerializeField]
    private AudioMixer myMixer;

    /// <summary>
    /// Slider for controlling master volume.
    /// </summary>
    [SerializeField]
    private Slider masterSlider;

    /// <summary>
    /// Slider for controlling music volume.
    /// </summary>
    [SerializeField]
    private Slider musicSlider;

    /// <summary>
    /// Slider for controlling SFX volume.
    /// </summary>
    [SerializeField]
    private Slider sFXSlider;

    /// <summary>
    /// Toggle button to mute/unmute audio.
    /// </summary>
    [SerializeField]
    private Toggle muteButton;

    /// <summary>
    /// Flag indicating if audio is currently muted.
    /// </summary>
    private bool isMuted = false;

    private void Start()
    {
        // Load saved volume settings if available; otherwise, set default volumes
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
            SetMasterVolume();
        }

        // Add listener to the mute toggle button
        if (muteButton != null)
        {
            muteButton.onValueChanged.AddListener(ToggleMute);
        }
    }

    /// <summary>
    /// Sets the music volume based on the musicSlider value.
    /// </summary>
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(volume) * 20); // Convert slider value to dB
        PlayerPrefs.SetFloat("musicVolume", volume); // Save volume setting
    }

    /// <summary>
    /// Sets the SFX volume based on the sFXSlider value.
    /// </summary>
    public void SetSFXVolume()
    {
        float volume = sFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20); // Convert slider value to dB
        PlayerPrefs.SetFloat("sFXVolume", volume); // Save volume setting
    }

    /// <summary>
    /// Sets the master volume based on the masterSlider value.
    /// </summary>
    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        myMixer.SetFloat("master", Mathf.Log10(volume) * 20); // Convert slider value to dB
        PlayerPrefs.SetFloat("masterVolume", volume); // Save volume setting
    }

    /// <summary>
    /// Toggles the mute state of all audio.
    /// </summary>
    /// <param name="isMuted">Current state of mute toggle.</param>
    public void ToggleMute(bool isMuted)
    {
        this.isMuted = !isMuted; // Toggle mute state

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

    /// <summary>
    /// Loads saved volume settings from PlayerPrefs.
    /// </summary>
    void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sFXSlider.value = PlayerPrefs.GetFloat("sFXVolume");
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");

        SetMusicVolume();
        SetSFXVolume();
        SetMasterVolume();
    }
}
