using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class AudioSettings : MonoBehaviour
{
    public Slider musicSlider, SFXSlider;
    private AudioManager audioManager;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        audioManager.MusicVolume(volume);
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        audioManager.SFXVolume(volume);
    }

    public void ToggleMusic()
    {
        audioManager.ToggleMusic(musicSlider);
    }

    public void ToggleSFX()
    {
        audioManager.ToggleSFX(SFXSlider);
    }
}
