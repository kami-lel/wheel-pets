using UnityEngine;
using UnityEngine.UI;

public class AudioControls : MonoBehaviour
{
    [SerializeField]
    private Slider musicVolumeSlider;

    [SerializeField]
    private Slider sfxVolumeSlider;

    [SerializeField]
    private Toggle muteMusicToggle;

    [SerializeField]
    private Toggle muteSfxToggle;

    private PlayerData data;

    private void Start()
    {
        data = Data.GetPlayerData();
        // Load settings from PlayerData
        LoadSettings();

        // Initialize the sliders and toggles
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
        muteMusicToggle.onValueChanged.AddListener(SetMuteMusic);
        muteSfxToggle.onValueChanged.AddListener(SetMuteSFX);

        // Set initial values
        UpdateUI();
    }

    private void LoadSettings()
    {
        musicVolumeSlider.value = data.musicVolume;
        sfxVolumeSlider.value = data.sfxVolume;
        muteMusicToggle.isOn = data.muteMusic;
        muteSfxToggle.isOn = data.muteSfx;
    }

    private void SaveSettings()
    {
        data.musicVolume = musicVolumeSlider.value;
        data.sfxVolume = sfxVolumeSlider.value;
        data.muteMusic = muteMusicToggle.isOn;
        data.muteSfx = muteSfxToggle.isOn;
    }

    private void UpdateUI()
    {
        // Update the UI elements based on the current values
        if (musicVolumeSlider != null)
        {
            musicVolumeSlider.value = data.musicVolume;
        }

        if (sfxVolumeSlider != null)
        {
            sfxVolumeSlider.value = data.sfxVolume;
        }

        if (muteMusicToggle != null)
        {
            muteMusicToggle.isOn = data.muteMusic;
        }

        if (muteSfxToggle != null)
        {
            muteSfxToggle.isOn = data.muteSfx;
        }
    }

    public void SetMusicVolume(float value)
    {
        data.musicVolume = value;
        SaveSettings();
        AudioManager.Instance.UpdateMusicVolume(value);
        // Update the UI
        UpdateUI();
    }

    public void SetSFXVolume(float value)
    {
        data.sfxVolume = value;
        SaveSettings();
        AudioManager.Instance.UpdateSFXVolume(value);
        // Update the UI
        UpdateUI();
    }

    public void SetMuteMusic(bool isMuted)
    {
        data.muteMusic = isMuted;
        SaveSettings();
        AudioManager.Instance.MuteMusic(isMuted);
        // Update the UI
        UpdateUI();
    }

    public void SetMuteSFX(bool isMuted)
    {
        data.muteSfx = isMuted;
        SaveSettings();
        AudioManager.Instance.MuteSFX(isMuted);
        // Update the UI
        UpdateUI();
    }
}
