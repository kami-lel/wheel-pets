using UnityEngine;
using UnityEngine.Audio;

// fixme make audio manager an prefab?
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
            Mathf.Log10(data.musicVolume) * 20
        );
        audioMixer.SetFloat(SFXVolumeParam, Mathf.Log10(data.sfxVolume) * 20);
        audioMixer.SetFloat(
            MusicVolumeParam,
            data.muteMusic ? -80 : Mathf.Log10(data.musicVolume) * 20
        );
        audioMixer.SetFloat(
            SFXVolumeParam,
            data.muteSfx ? -80 : Mathf.Log10(data.sfxVolume) * 20
        );
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
        audioMixer.SetFloat(
            MusicVolumeParam,
            mute ? -80 : Mathf.Log10(Data.GetPlayerData().musicVolume) * 20
        );
    }

    public void MuteSFX(bool mute)
    {
        audioMixer.SetFloat(
            SFXVolumeParam,
            mute ? -80 : Mathf.Log10(Data.GetPlayerData().sfxVolume) * 20
        );
    }
}
