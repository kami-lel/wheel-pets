using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSoundHandler : MonoBehaviour
{
    void Start()
    {
        AttachButtonSoundHandlers();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AttachButtonSoundHandlers();
    }

    private void AttachButtonSoundHandlers()
    {
        // Find all buttons in the scene and add the OnClick listener
        Button[] buttons = FindObjectsByType<Button>(0);

        foreach (Button button in buttons)
        {
            AddEventTrigger(
                button.gameObject,
                EventTriggerType.PointerClick,
                OnButtonClick
            );
        }
    }

    private void AddEventTrigger(
        GameObject obj,
        EventTriggerType type,
        System.Action<BaseEventData> action
    )
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            trigger = obj.AddComponent<EventTrigger>();
        }

        EventTrigger.Entry entry = new EventTrigger.Entry { eventID = type };
        entry.callback.AddListener((eventData) => action(eventData));
        trigger.triggers.Add(entry);
    }

    private void OnButtonClick(BaseEventData eventData)
    {
        ButtonSoundManager.PlayButtonClickSound();
    }
}
