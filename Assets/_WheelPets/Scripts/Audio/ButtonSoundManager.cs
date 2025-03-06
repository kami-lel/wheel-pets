using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSoundManager : MonoBehaviour
{
    private static ButtonSoundManager instance;

    [SerializeField] private AudioClip buttonClickSound;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = gameObject.AddComponent<AudioSource>();
            gameObject.AddComponent<ButtonSoundHandler>(); // Add ButtonSoundHandler to the same GameObject
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void PlayButtonClickSound()
    {
        if (instance != null && instance.buttonClickSound != null)
        {
            instance.audioSource.PlayOneShot(instance.buttonClickSound);
        }
    }
}
