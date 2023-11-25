using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("--- audio source ---")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--- audio clip ---")]
    public AudioClip background;
    public AudioClip shoot;
    public AudioClip hitEffect;
    public AudioClip explosion;
    public AudioClip spaceShipCollision;

    [Header("--- image ---")]
    public Sprite volume;
    public Sprite muteVolume;
    public Sprite sfx;
    public Sprite muteSFX;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void ToggleMusic(Button b, Slider s)
    {
        if(PlayerPrefs.HasKey("muteMusic"))
        {
            musicSource.mute = !musicSource.mute;
            s.enabled = !musicSource.mute;
        }
        else
        {
            musicSource.mute = false;
            s.enabled = true;
        }

        b.image.sprite = musicSource.mute ? muteVolume : volume;

        PlayerPrefs.SetInt("muteMusic", musicSource.mute ? 1 : 0);
    }

    public void ToggleMusic(Button b, Slider s, bool value)
    {
        musicSource.mute = value;
        s.enabled = !musicSource.mute;

        b.image.sprite = musicSource.mute ? muteVolume : volume;

        PlayerPrefs.SetInt("muteMusic", musicSource.mute ? 1 : 0);
    }

    public void ToggleSFX(Button b, Slider s)
    {
        if (PlayerPrefs.HasKey("muteSFX"))
        {
            SFXSource.mute = !SFXSource.mute;
            s.enabled = !SFXSource.mute;
        }
        else
        {
            SFXSource.mute = false;
            s.enabled = true;
        }

        b.image.sprite = SFXSource.mute ? muteSFX : sfx;

        PlayerPrefs.SetInt("muteSFX", SFXSource.mute ? 1 : 0);
    }

    public void ToggleSFX(Button b, Slider s, bool value)
    {
        SFXSource.mute = value;
        s.enabled = !SFXSource.mute;

        b.image.sprite = SFXSource.mute ? muteSFX : sfx;

        PlayerPrefs.SetInt("muteSFX", SFXSource.mute ? 1 : 0);
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        SFXSource.volume = volume;
    }

}
