using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BathGame : SceneSwapping
{
    [SerializeField]
    public BoxCollider2D targetCollider; // The collider to check for collisions with

    [SerializeField]
    public TextMeshProUGUI mistakeText; // Text to display mistakes

    [SerializeField]
    public TextMeshProUGUI messageText; // Text to display messages

    [SerializeField]
    public TextMeshProUGUI timerText; // Text to display the timer

    public GameOverManager gameOverManager;

    // Order booleans
    private bool isBrushUsed = false;
    private bool isClippersUsed = false;
    private bool isSoapUsed = false;
    private bool isWaterUsed = false;
    private bool isTowelUsed = false;
    private bool isScissorsUsed = false;

    [SerializeField]
    AudioSource backgroundMusic; // Audio source for background music

    [SerializeField]
    private List<GameObject> draggableItems; // List of draggable items

    [SerializeField]
    private float circleRadius = 200f; // Radius of the circle around the dog

    private float timer = 0f;
    private bool gameActive = false;

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

        // Start the timer
        gameActive = true;

        // Get reference to the BathSceneScript
        sceneScript = FindFirstObjectByType<BathSceneScript>();
    }

    public void BackButtonOnClick()
    {
        SceneChange.LoadSelector();
    }

    void Update()
    {
        if (gameActive)
        {
            timer += Time.deltaTime;
            UpdateTimerText();
        }

        // Check if mistakes reached "XXX" and switch to PetGame Scene
        if (mistakeText.text == "XXX")
        {
            gameActive = false;
            gameOverManager.ShowGameOver();
            if (sceneScript != null)
            {
                sceneScript.ShowPlayAgainButton();
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
                }
                else
                {
                    DisplayMistake("X");
                    DisplayMessage("You can't use that yet.");
                }
            }
            else if (itemTag == "clippers")
            {
                if (isBrushUsed && !isClippersUsed)
                {
                    isClippersUsed = true;
                    DisplayMessage("The dog has been clipped.");
                    RemoveItem(draggedItem);
                }
                else
                {
                    DisplayMistake("X");
                    DisplayMessage("You can't use that yet.");
                }
            }
            else if (itemTag == "soap")
            {
                if (isBrushUsed && isClippersUsed && !isSoapUsed)
                {
                    isSoapUsed = true;
                    DisplayMessage("The dog is lathered.");
                    RemoveItem(draggedItem);
                }
                else
                {
                    DisplayMistake("X");
                    DisplayMessage("You can't use that yet.");
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
                }
                else
                {
                    DisplayMistake("X");
                    DisplayMessage("You can't use that yet.");
                }
            }
            else if (itemTag == "towel")
            {
                if (isWaterUsed && !isTowelUsed)
                {
                    isTowelUsed = true;
                    DisplayMessage("The dog is dried off.");
                    RemoveItem(draggedItem);
                }
                else
                {
                    DisplayMistake("X");
                    DisplayMessage("You can't use that yet.");
                }
            }
            else if (itemTag == "scissors")
            {
                if (isTowelUsed && !isScissorsUsed)
                {
                    isScissorsUsed = true;
                    DisplayMessage("All done");
                    RemoveItem(draggedItem);
                    gameActive = false; // Stop the timer
                    SaveHighScore(); // Save the high score if the player completes the dog washing
                    if (sceneScript != null)
                    {
                        sceneScript.ShowPlayAgainButton();
                    }
                }
                else
                {
                    DisplayMistake("X");
                    DisplayMessage("You can't use that yet.");
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

    void PauseBackgroundMusic()
    {
        backgroundMusic.Pause();
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
        PlayerData playerData = Data.GetPlayerData();
        if (timerText != null)
        {
            timerText.text =
                "Lowest Time: "
                + playerData.bathMinigameBestTime.ToString("F2")
                + "s\nTime: "
                + timer.ToString("F2")
                + "s";
        }
    }

    private void SaveHighScore()
    {
        PlayerData playerData = Data.GetPlayerData();
        if (
            timer < playerData.bathMinigameBestTime
            || playerData.bathMinigameBestTime == 60f
        )
        {
            playerData.bathMinigameBestTime = timer;
        }
    }
}
