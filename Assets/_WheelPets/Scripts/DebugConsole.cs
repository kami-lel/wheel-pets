using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// DebugConsole allows developers to input and execute debug commands during development builds.
/// This console can be toggled using the ` key.
/// Place the Prefab under a Canvas for it to work.
/// </summary>
public class DebugConsole : MonoBehaviour
{
    [SerializeField]
    private GameObject container;

    [SerializeField]
    private TMP_InputField commandField;

    [SerializeField]
    private Button SaveToFileButton;

    [SerializeField]
    private Button LoadFromFileButton;

    [SerializeField]
    private Button ResetButton;

    private void Start()
    {
        // Debug Console is only available in dev builds
        if (!Debug.isDebugBuild)
        {
            return;
        }

        // disable by default
        container.SetActive(false);
        Debug.Log("DebugConsole\tStart");

        // event listner for commandField
        if (commandField != null)
        {
            commandField.onEndEdit.AddListener(HandleEndEdit);
        }

        // player data
        SaveToFileButton.onClick.AddListener(() =>
        {
            PlayerData.SaveToFile();
        });
        LoadFromFileButton.onClick.AddListener(() =>
        {
            PlayerData.LoadFromFile();
        });
        ResetButton.onClick.AddListener(() =>
        {
            PlayerData.ResetPlayerData();
        });
    }

    private void Update()
    {
        // Debug Console is only available in dev builds
        if (!Debug.isDebugBuild)
        {
            return;
        }

        // toggle the debug console
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            container.SetActive(!container.activeInHierarchy);
            Debug.Log("DebugConsole\tToggled");
        }

        if (container.activeInHierarchy && Input.GetKeyDown(KeyCode.UpArrow) && lastComamnd != null)
        {
            commandField.text = lastComamnd;
        }
    }

    private static string lastComamnd = null;

    private void HandleEndEdit(string inputText)
    {
        string[] args = inputText.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        bool success;

        switch (args[0])
        {
            case "car":
                success = ExecuteCommandCar(args);
                break;

            case "scene":
                success = ExecuteCommandScene(args);
                break;

            default:
                success = false;
                break;
        }

        if (!success)
        {
            Debug.LogWarning($"DebugConsole\tbad command: {inputText}");
        }

        lastComamnd = inputText;
        // clean up
        commandField.text = string.Empty;
        container.SetActive(false);
    }

    private bool ExecuteCommandCar(string[] args)
    {
        string enumName = args[1];

        if (Enum.TryParse(enumName, out CarAPI.Event eve))
        {
            CarAPI.Emit(eve);
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool ExecuteCommandScene(string[] args)
    {
        string sceneName = string.Join(" ", args.Skip(1).ToArray());
        SceneManager.LoadScene(sceneName);
        return true;
    }

    private void OnDestroy()
    {
        if (commandField != null)
        {
            commandField.onEndEdit.RemoveListener(HandleEndEdit);
        }
    }
}
