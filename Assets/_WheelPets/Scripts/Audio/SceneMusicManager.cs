using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMusicManager : MonoBehaviour
{
    [SerializeField] private string[] scenesToMute;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (audioSource == null) return;

        if (ShouldMuteScene(scene.name))
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.UnPause();
        }
    }

    private bool ShouldMuteScene(string sceneName)
    {
        foreach (string sceneToMute in scenesToMute)
        {
            if (sceneToMute == sceneName)
            {
                return true;
            }
        }
        return false;
    }
}