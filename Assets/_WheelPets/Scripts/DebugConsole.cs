using System;
using System.Linq;
using TMPro;
using UnityEditor.Scripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugConsole : MonoBehaviour
{
    [SerializeField]
    private GameObject container;

    [SerializeField]
    private TMP_InputField inputField;

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

        // set up event listner
        if (inputField != null)
        {
            inputField.onEndEdit.AddListener(HandleEndEdit);
        }
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
            inputField.text = lastComamnd;
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
        inputField.text = string.Empty;
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
        if (inputField != null)
        {
            inputField.onEndEdit.RemoveListener(HandleEndEdit);
        }
    }
}
