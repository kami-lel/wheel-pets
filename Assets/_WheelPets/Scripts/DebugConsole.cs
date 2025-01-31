using System;
using TMPro;
using UnityEngine;

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
    }

    private void HandleEndEdit(string inputText)
    {
        string[] args = inputText.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        switch (args[0])
        {
            case "car":
                CmdCar(args);
                break;

            case "scene":
                CmdScene(args);
                break;

            default:
                Debug.LogWarning($"DebugConsole\tcommand \"{args[0]}\" unrecognized");
                break;
        }

        // clean up
        inputField.text = string.Empty;
        container.SetActive(false);
    }

    private void CmdCar(string[] args) { }

    private void CmdScene(string[] args) { }

    private void OnDestroy()
    {
        if (inputField != null)
        {
            inputField.onEndEdit.RemoveListener(HandleEndEdit);
        }
    }
}
