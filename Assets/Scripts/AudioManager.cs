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

    public void ToggleMusic(Slider s)
    {
        musicSource.mute = !musicSource.mute;
        s.enabled = !musicSource.mute;
    }

    public void ToggleSFX(Slider s)
    {
        SFXSource.mute = !SFXSource.mute;
        s.enabled = !SFXSource.mute;
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
