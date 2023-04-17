using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UIController : MonoBehaviour
{
    public Slider _Musicslider, _SfxSlider;
    void Start()
    {
        // Mengatur nilai volume musik dan efek suara berdasarkan nilai yang disimpan di PlayerPrefs
        float musicVolume = PlayerPrefs.GetFloat("musicVolume", 1f);
        AudioManager.Instance.MusicVolume(musicVolume);
        _Musicslider.value = musicVolume;

        float sfxVolume = PlayerPrefs.GetFloat("sfxVolume", 1f);
        AudioManager.Instance.SFXVolume(sfxVolume);
        _SfxSlider.value = sfxVolume;

        int musicMute = PlayerPrefs.GetInt("musicMute", 0);
        AudioManager.Instance.musicSource.mute = musicMute == 1;

        int sfxMute = PlayerPrefs.GetInt("sfxMute", 0);
        AudioManager.Instance.sfxSource.mute = sfxMute == 1;
    }
    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();

        // Simpan status mute musik ke PlayerPrefs
        int musicMute = AudioManager.Instance.musicSource.mute ? 1 : 0;
        PlayerPrefs.SetInt("musicMute", musicMute);
        PlayerPrefs.Save();
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();

        // Simpan status mute efek suara ke PlayerPrefs
        int sfxMute = AudioManager.Instance.sfxSource.mute ? 1 : 0;
        PlayerPrefs.SetInt("sfxMute", sfxMute);
        PlayerPrefs.Save();
    }

    public void MusicVolume(float volume)
    {
        AudioManager.Instance.MusicVolume(volume);

        // Simpan nilai volume musik ke PlayerPrefs
        PlayerPrefs.SetFloat("musicVolume", volume);
        PlayerPrefs.Save();
    }

    public void SfxVolume(float volume)
    {
        AudioManager.Instance.SFXVolume(volume);

        // Simpan nilai volume efek suara ke PlayerPrefs
        PlayerPrefs.SetFloat("sfxVolume", volume);
        PlayerPrefs.Save();
    }
}
