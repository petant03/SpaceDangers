using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] Slider musicSlider, SFXSlider;
    private AudioManager audioManager;

    private void Start()
    {
        LoadAudioPrefs();
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    #region Volume
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        audioManager.MusicVolume(volume);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        audioManager.SFXVolume(volume);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    #endregion

    #region Toggle
    public void ToggleMusic()
    {
        audioManager.ToggleMusic(musicSlider);
    }

    public void ToggleMusic(bool value)
    {
        audioManager.ToggleMusic(musicSlider,value);
    }

    public void ToggleSFX()
    {
        audioManager.ToggleSFX(SFXSlider);
    }

    public void ToggleSFX(bool value)
    {
        audioManager.ToggleSFX(SFXSlider, value);
    }
    #endregion

    private void LoadAudioPrefs()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        else
            SetMusicVolume();

        if(PlayerPrefs.HasKey("SFXVolume"))
            SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        else
            SetSFXVolume();

        if(PlayerPrefs.HasKey("muteMusic"))
        {
            bool muteMusic = PlayerPrefs.GetInt("muteMusic") == 1;
            ToggleMusic(muteMusic);
        }
        else
            ToggleMusic();

        if (PlayerPrefs.HasKey("muteSFX"))
        {
            bool muteSFX = PlayerPrefs.GetInt("muteSFX") == 1;
            ToggleSFX(muteSFX);
        }
        else
            ToggleSFX();
    }
}
