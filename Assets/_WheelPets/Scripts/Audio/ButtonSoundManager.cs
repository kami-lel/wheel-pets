using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSoundManager : MonoBehaviour
{
    private static ButtonSoundManager instance;

    [SerializeField] private AudioSource buttonClickAudioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            gameObject.AddComponent<ButtonSoundHandler>(); // Add ButtonSoundHandler to the same GameObject
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void PlayButtonClickSound()
    {
        if (instance != null && instance.buttonClickAudioSource != null)
        {
            instance.buttonClickAudioSource.Play();
        }
    }
}
