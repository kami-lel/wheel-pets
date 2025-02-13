using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioMixer audioMixer;
    private const string MusicVolumeParam = "MusicVolume";
    private const string SFXVolumeParam = "SFXVolume";

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
            return;
        }

        // Load settings from PlayerData
        LoadSettings();
    }

    private void LoadSettings()
    {
        PlayerData data = PlayerData.Data;

        audioMixer.SetFloat(MusicVolumeParam, Mathf.Log10(data.musicVolume) * 20);
        audioMixer.SetFloat(SFXVolumeParam, Mathf.Log10(data.sfxVolume) * 20);
        audioMixer.SetFloat(MusicVolumeParam + "Mute", data.muteMusic ? -80 : 0);
        audioMixer.SetFloat(SFXVolumeParam + "Mute", data.muteSfx ? -80 : 0);
    }

    public void UpdateMusicVolume(float volume)
    {
        audioMixer.SetFloat(MusicVolumeParam, Mathf.Log10(volume) * 20);
    }

    public void UpdateSFXVolume(float volume)
    {
        audioMixer.SetFloat(SFXVolumeParam, Mathf.Log10(volume) * 20);
    }

    public void MuteMusic(bool mute)
    {
        audioMixer.SetFloat(MusicVolumeParam + "Mute", mute ? -80 : 0);
    }

    public void MuteSFX(bool mute)
    {
        audioMixer.SetFloat(SFXVolumeParam + "Mute", mute ? -80 : 0);
    }
}
