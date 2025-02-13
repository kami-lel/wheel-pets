using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource musicSource;
    private AudioSource sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Initialize audio sources
        musicSource = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();

        // Load settings from PlayerData
        LoadSettings();
    }

    private void LoadSettings()
    {
        PlayerData data = PlayerData.Data;

        musicSource.volume = data.musicVolume;
        sfxSource.volume = data.sfxVolume;
        musicSource.mute = data.muteMusic;
        sfxSource.mute = data.muteSfx;
    }

    public void UpdateMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void UpdateSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    public void MuteMusic(bool mute)
    {
        musicSource.mute = mute;
    }

    public void MuteSFX(bool mute)
    {
        sfxSource.mute = mute;
    }
}
