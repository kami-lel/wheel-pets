using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BathGame : MonoBehaviour
{
    public BoxCollider2D targetCollider; // The collider to check for collisions with

    [SerializeField]
    private TextMeshProUGUI mistakeText; // Text to display mistakes

    [SerializeField]
    private TextMeshProUGUI messageText; // Text to display messages

    [SerializeField]
    private TextMeshProUGUI timerText; // Text to display the timer

    public PauseOverlay pauseOverlay;

    // Order booleans
    private bool isBrushUsed = false;

    [SerializeField]
    private AudioSource BrushSound;
    private bool isClippersUsed = false;

    [SerializeField]
    private AudioSource ClipperSound;
    private bool isSoapUsed = false;

    [SerializeField]
    private AudioSource SoapSound;
    private bool isWaterUsed = false;

    [SerializeField]
    private AudioSource WaterSound;
    private bool isTowelUsed = false;

    [SerializeField]
    private AudioSource TowelSound;
    private bool isScissorsUsed = false;

    [SerializeField]
    private AudioSource ScissorSound;

    [SerializeField]
    private AudioSource MistakeSound;

    [SerializeField]
    AudioSource backgroundMusic; // Audio source for background music

    [SerializeField]
    private List<GameObject> draggableItems; // List of draggable items

    [SerializeField]
    private float circleRadius = 200f; // Radius of the circle around the dog

    private float timer = 0f;

    private BathSceneScript sceneScript;

    void Start()
    {
        if (targetCollider == null)
        {
            Debug.LogError("Target collider not assigned in the Inspector!");
        }

        if (messageText == null || mistakeText == null || timerText == null)
        {
            Debug.LogError(
                "TextMeshProUGUI components not assigned in the Inspector!"
            );
        }

        // Play BG music on start
        PlayBackgroundMusic();

        // Spawn draggable items in a circle around the dog
        SpawnDraggableItems();

        // Get reference to the BathSceneScript
        sceneScript = FindFirstObjectByType<BathSceneScript>();
    }

    public void BackButtonOnClick()
    {
        SceneChange.LoadSelector();
    }

    void Update()
    {
        if (pauseOverlay.status == PauseOverlay.Status.Running)
        {
            timer += Time.deltaTime;
            UpdateTimerText();

            // Check if mistakes reached "XXX" and switch to PetGame Scene
            if (mistakeText.text == "XXX")
            {
                Data.GetPlayerData().statBath.RecordLose(timer);
                pauseOverlay.MinigameLost();
                if (sceneScript != null)
                {
                    sceneScript.ShowPlayAgainButton();
                }
            }
        }
    }

    public void NotifyItemDragged(string itemTag)
    {
        Debug.Log($"NotifyItemDragged called with itemTag: {itemTag}");
        GameObject draggedItem = GameObject.FindWithTag(itemTag);

        if (mistakeText.text != "XXX" && !isScissorsUsed) // Check if mistakes are less than 3 and towel is not used
        {
            if (itemTag == "brush")
            {
                if (!isBrushUsed)
                {
                    isBrushUsed = true;
                    DisplayMessage("The dog is brushed and looking tidy.");
                    RemoveItem(draggedItem);
                    BrushSound.Play();
                    Invoke(nameof(StopAllSounds), 1f);
                }
                else
                {
                    DisplayMistake("X");
                    DisplayMessage("You can't use that yet.");
                    MistakeSound.Play();
                    Invoke(nameof(StopAllSounds), 1f);
                }
            }
            else if (itemTag == "clippers")
            {
                if (isBrushUsed && !isClippersUsed)
                {
                    isClippersUsed = true;
                    DisplayMessage("The dog has been clipped.");
                    RemoveItem(draggedItem);
                    ClipperSound.Play();
                    Invoke(nameof(StopAllSounds), 1f);
                }
                else
                {
                    DisplayMistake("X");
                    DisplayMessage("You can't use that yet.");
                    MistakeSound.Play();
                    Invoke(nameof(StopAllSounds), 1f);
                }
            }
            else if (itemTag == "soap")
            {
                if (isBrushUsed && isClippersUsed && !isSoapUsed)
                {
                    isSoapUsed = true;
                    DisplayMessage("The dog is lathered.");
                    RemoveItem(draggedItem);
                    SoapSound.Play();
                    Invoke(nameof(StopAllSounds), 1f);
                }
                else
                {
                    DisplayMistake("X");
                    DisplayMessage("You can't use that yet.");
                    MistakeSound.Play();
                    Invoke(nameof(StopAllSounds), 1f);
                }
            }
            else if (itemTag == "water")
            {
                if (
                    isBrushUsed
                    && isClippersUsed
                    && isSoapUsed
                    && !isWaterUsed
                )
                {
                    isWaterUsed = true;
                    DisplayMessage("The dog is rinsed.");
                    RemoveItem(draggedItem);
                    WaterSound.Play();
                    Invoke(nameof(StopAllSounds), 1f);
                }
                else
                {
                    DisplayMistake("X");
                    DisplayMessage("You can't use that yet.");
                    MistakeSound.Play();
                    Invoke(nameof(StopAllSounds), 1f);
                }
            }
            else if (itemTag == "towel")
            {
                if (isWaterUsed && !isTowelUsed)
                {
                    isTowelUsed = true;
                    DisplayMessage("The dog is dried off.");
                    RemoveItem(draggedItem);
                    TowelSound.Play();
                    Invoke(nameof(StopAllSounds), 1f);
                }
                else
                {
                    DisplayMistake("X");
                    DisplayMessage("You can't use that yet.");
                    MistakeSound.Play();
                    Invoke(nameof(StopAllSounds), 1f);
                }
            }
            else if (itemTag == "scissors")
            {
                if (isTowelUsed && !isScissorsUsed)
                {
                    isScissorsUsed = true;
                    DisplayMessage("All done");
                    RemoveItem(draggedItem);
                    ScissorSound.Play();
                    Invoke(nameof(StopAllSounds), 1f);
                    pauseOverlay.MinigameWin();
                    Data.GetPlayerData().statBath.RecordWin(timer);
                    if (sceneScript != null)
                    {
                        sceneScript.ShowPlayAgainButton();
                    }
                }
                else
                {
                    DisplayMistake("X");
                    DisplayMessage("You can't use that yet.");
                    MistakeSound.Play();
                    Invoke(nameof(StopAllSounds), 1f);
                }
            }

            // Respawn remaining items in a circle around the dog
            SpawnDraggableItems();
        }
    }

    private void RemoveItem(GameObject item)
    {
        if (item != null)
        {
            item.SetActive(false); // Make the item invisible and non-interactable
            draggableItems.Remove(item); // Remove the item from the list
        }
    }

    private void DisplayMistake(string mistake)
    {
        if (mistakeText != null)
        {
            mistakeText.text += mistake; // Append mistake
        }
    }

    private void DisplayMessage(string message)
    {
        if (messageText != null)
        {
            messageText.text = message;
        }
    }

    void PlayBackgroundMusic()
    {
        backgroundMusic.Play();
    }

    private void SpawnDraggableItems()
    {
        ShuffleList(draggableItems); // Shuffle the list before spawning

        float angleStep = 360f / draggableItems.Count;
        float angle = 0f;

        foreach (GameObject item in draggableItems)
        {
            float itemPosX =
                targetCollider.transform.position.x
                + Mathf.Sin(angle * Mathf.Deg2Rad) * circleRadius;
            float itemPosY =
                targetCollider.transform.position.y
                + Mathf.Cos(angle * Mathf.Deg2Rad) * circleRadius;

            Vector3 itemPos = new Vector3(itemPosX, itemPosY, 0);
            item.transform.position = itemPos;

            // Set the original position for each draggable item
            BathDraggables draggableScript =
                item.GetComponent<BathDraggables>();
            if (draggableScript != null)
            {
                draggableScript.SetOriginalPosition(itemPos);
            }

            item.SetActive(true); // Make the item visible and interactable

            angle += angleStep;
        }
    }

    private void ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            T temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    private void UpdateTimerText()
    {
        float bestTime = Data.GetPlayerData().statBath.bestScore;
        if (timerText != null)
        {
            timerText.text =
                "Lowest Time: "
                + bestTime.ToString("F2")
                + "s\nTime: "
                + timer.ToString("F2")
                + "s";
        }
    }

private void StopAllSounds()
{
    BrushSound.Stop();
    ClipperSound.Stop();
    SoapSound.Stop();
    WaterSound.Stop();
    TowelSound.Stop();
    ScissorSound.Stop();
    MistakeSound.Stop();
}
}