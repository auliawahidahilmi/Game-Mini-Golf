using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSound, sfxSound;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("BGM");
        //DontDestroyOnLoad(this.gameObject);
    }

    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(musicSound, music => music.name == name);

        if(sound == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            musicSource.clip = sound.clip;
            musicSource.Play();
            
        }
    }

    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(sfxSound, music => music.name == name);

        if (sound == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            sfxSource.PlayOneShot(sound.clip);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}

