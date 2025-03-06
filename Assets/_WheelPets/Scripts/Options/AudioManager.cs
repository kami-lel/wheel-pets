using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField]
    private AudioMixer audioMixer;
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
        PlayerData data = Data.GetPlayerData();

        audioMixer.SetFloat(
            MusicVolumeParam,
            data.musicVolume > 0 ? Mathf.Log10(data.musicVolume) * 20 : -80
        );
        audioMixer.SetFloat(
            SFXVolumeParam,
            data.sfxVolume > 0 ? Mathf.Log10(data.sfxVolume) * 20 : -80
        );
        audioMixer.SetFloat(
            MusicVolumeParam,
            data.muteMusic ? -80 : (data.musicVolume > 0 ? Mathf.Log10(data.musicVolume) * 20 : -80)
        );
        audioMixer.SetFloat(
            SFXVolumeParam,
            data.muteSfx ? -80 : (data.sfxVolume > 0 ? Mathf.Log10(data.sfxVolume) * 20 : -80)
        );
    }

    public void UpdateMusicVolume(float volume)
    {
        audioMixer.SetFloat(MusicVolumeParam, volume > 0 ? Mathf.Log10(volume) * 20 : -80);
    }

    public void UpdateSFXVolume(float volume)
    {
        audioMixer.SetFloat(SFXVolumeParam, volume > 0 ? Mathf.Log10(volume) * 20 : -80);
    }

    public void MuteMusic(bool mute)
    {
        audioMixer.SetFloat(
            MusicVolumeParam,
            mute ? -80 : (Data.GetPlayerData().musicVolume > 0 ? Mathf.Log10(Data.GetPlayerData().musicVolume) * 20 : -80)
        );
    }

    public void MuteSFX(bool mute)
    {
        audioMixer.SetFloat(
            SFXVolumeParam,
            mute ? -80 : (Data.GetPlayerData().sfxVolume > 0 ? Mathf.Log10(Data.GetPlayerData().sfxVolume) * 20 : -80)
        );
    }
}
