using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}
