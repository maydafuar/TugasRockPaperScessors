using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{

public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    [SerializeField] private AudioSource s;

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
        PlayMusic("Music");
        
        if (PlayerPrefs.HasKey("musicMute"))
        {
            bool musicMute = PlayerPrefs.GetInt("musicMute") == 1 ? true : false;
            musicSource.mute = musicMute;
        }

        if (PlayerPrefs.HasKey("sfxMute"))
        {
            bool sfxMute = PlayerPrefs.GetInt("sfxMute") == 1 ? true : false;
            sfxSource.mute = sfxMute;
        }

        if (PlayerPrefs.HasKey("musicVolume"))
        {
            float musicVolume = PlayerPrefs.GetFloat("musicVolume");
            musicSource.volume = musicVolume;
        }

        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            float sfxVolume = PlayerPrefs.GetFloat("sfxVolume");
            sfxSource.volume = sfxVolume;
        }

        if (PlayerPrefs.HasKey("currentMusic"))
        {
            string currentMusic = PlayerPrefs.GetString("currentMusic");
            PlayMusic(currentMusic);
        }

        if (PlayerPrefs.HasKey("currentSFX"))
        {
            string currentSFX = PlayerPrefs.GetString("currentSFX");
            PlaySFX(currentSFX);
        }
    }

    //Script play music
    //script di fold dengan shortcut ctrl + shift + [ atau ]
   
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Music diputar");
        }

        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
            PlayerPrefs.SetString("currentMusic", name);
        }
    }

    public void PlaySFX(string name)
    {
        
            sfxSource.PlayOneShot(s.clip);
            PlayerPrefs.SetString("currentSFX", name);
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
        PlayerPrefs.SetInt("musicMute", musicSource.mute ? 1 : 0);
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
        PlayerPrefs.SetInt("sfxMute", sfxSource.mute ? 1 : 0);
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

   



}
