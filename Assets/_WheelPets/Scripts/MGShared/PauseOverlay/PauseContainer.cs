using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// fixme need ui re-design
public class PauseContainer : MonoBehaviour
{
    private PauseOverlay pauseOverlay;
    private AudioSource audioSource;
    public AudioClip volumeChangeSFX;
    public Slider volumeSlider;

    private void Awake()
    {
        pauseOverlay = FindFirstObjectByType<PauseOverlay>();
        audioSource = gameObject.AddComponent<AudioSource>();

        // creates event on pointer release when changing volume
        if (volumeSlider != null)
        {
            EventTrigger trigger = volumeSlider.gameObject.GetComponent<EventTrigger>();
            if (trigger == null)
            {
                trigger = volumeSlider.gameObject.AddComponent<EventTrigger>();
            }

            EventTrigger.Entry entry = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerUp
            };
            entry.callback.AddListener((data) => OnVolumeSliderReleased());
            trigger.triggers.Add(entry);
        }
    }

    private void OnEnable()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("PauseOverlay\tPause Screen Shown");
        }
        pauseOverlay.StopMinigameTimeAndAudio();
        pauseOverlay.status = PauseOverlay.Status.Paused;
    }

    public void OnClickResumeButton()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("PauseOverlay\tGame Resumed");
        }

        pauseOverlay.ContinueMinigameTimeAndAudio();
        pauseOverlay.status = PauseOverlay.Status.Running;
        gameObject.SetActive(false);
    }

    public void OnClickExitButton()
    {
        pauseOverlay.ContinueMinigameTimeAndAudio();
        SceneChange.LoadSelector();
    }

    public void VolumeSliderOnValueChanged(Single value)
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log($"PauseOverlay\tmain volume changed to {value}");
        }
        
        AudioListener.volume = value;
    }

    private void OnVolumeSliderReleased()
    {
        if (volumeChangeSFX != null)
        {
            audioSource.volume = volumeSlider.value; // Set sound effect volume based on slider
            audioSource.PlayOneShot(volumeChangeSFX);
        }
        else
        {
            Debug.LogWarning("Volume change sound effect not assigned!");
        }
    }
}
