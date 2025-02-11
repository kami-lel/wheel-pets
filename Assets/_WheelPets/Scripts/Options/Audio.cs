using UnityEngine;
using UnityEngine.UI;

public class AudioControls : MonoBehaviour
{
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private Toggle muteMusicToggle;
    [SerializeField] private Toggle muteSfxToggle;

    public float MusicVolume = 1f;
    public float SFXVolume = 1f;
    public bool MuteMusic = false;
    public bool MuteSFX = false;

    private void Start()
    {
        // Initialize the sliders and toggles
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
        muteMusicToggle.onValueChanged.AddListener(SetMuteMusic);
        muteSfxToggle.onValueChanged.AddListener(SetMuteSFX);

        // Set initial values
        musicVolumeSlider.value = MusicVolume;
        sfxVolumeSlider.value = SFXVolume;
        muteMusicToggle.isOn = MuteMusic;
        muteSfxToggle.isOn = MuteSFX;

        // Update the UI
        UpdateUI();
    }

    private void UpdateUI()
    {
        // Update the UI elements based on the current values
        if (musicVolumeSlider != null)
        {
            musicVolumeSlider.value = MusicVolume;
        }

        if (sfxVolumeSlider != null)
        {
            sfxVolumeSlider.value = SFXVolume;
        }

        if (muteMusicToggle != null)
        {
            muteMusicToggle.isOn = MuteMusic;
        }

        if (muteSfxToggle != null)
        {
            muteSfxToggle.isOn = MuteSFX;
        }
    }

    public void SetMusicVolume(float value)
    {
        MusicVolume = value;
        // Update the UI
        UpdateUI();
    }

    public void SetSFXVolume(float value)
    {
        SFXVolume = value;
        // Update the UI
        UpdateUI();
    }

    public void SetMuteMusic(bool isMuted)
    {
        MuteMusic = isMuted;
        // Update the UI
        UpdateUI();
    }

    public void SetMuteSFX(bool isMuted)
    {
        MuteSFX = isMuted;
        // Update the UI
        UpdateUI();
    }
}