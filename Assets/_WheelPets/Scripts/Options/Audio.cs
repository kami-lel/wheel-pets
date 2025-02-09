using UnityEngine;
using UnityEngine.UI;

public class AudioControls : MonoBehaviour
{
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private Toggle muteMusicToggle;
    [SerializeField] private Toggle muteSfxToggle;

    private void Start()
    {
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
        PlayerData data = PlayerData.Data;

        musicVolumeSlider.value = data.musicVolume;
        sfxVolumeSlider.value = data.sfxVolume;
        muteMusicToggle.isOn = data.muteMusic;
        muteSfxToggle.isOn = data.muteSfx;
    }

    private void SaveSettings()
    {
        PlayerData data = PlayerData.Data;

        data.musicVolume = musicVolumeSlider.value;
        data.sfxVolume = sfxVolumeSlider.value;
        data.muteMusic = muteMusicToggle.isOn;
        data.muteSfx = muteSfxToggle.isOn;

        PlayerData.SaveToFile();
    }

    private void UpdateUI()
    {
        // Update the UI elements based on the current values
        if (musicVolumeSlider != null)
        {
            musicVolumeSlider.value = PlayerData.Data.musicVolume;
        }

        if (sfxVolumeSlider != null)
        {
            sfxVolumeSlider.value = PlayerData.Data.sfxVolume;
        }

        if (muteMusicToggle != null)
        {
            muteMusicToggle.isOn = PlayerData.Data.muteMusic;
        }

        if (muteSfxToggle != null)
        {
            muteSfxToggle.isOn = PlayerData.Data.muteSfx;
        }
    }

    public void SetMusicVolume(float value)
    {
        PlayerData.Data.musicVolume = value;
        SaveSettings();
        // Update the UI
        UpdateUI();
    }

    public void SetSFXVolume(float value)
    {
        PlayerData.Data.sfxVolume = value;
        SaveSettings();
        // Update the UI
        UpdateUI();
    }

    public void SetMuteMusic(bool isMuted)
    {
        PlayerData.Data.muteMusic = isMuted;
        SaveSettings();
        // Update the UI
        UpdateUI();
    }

    public void SetMuteSFX(bool isMuted)
    {
        PlayerData.Data.muteSfx = isMuted;
        SaveSettings();
        // Update the UI
        UpdateUI();
    }
}