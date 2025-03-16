using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BathBar : MonoBehaviour
{
    [SerializeField] private Image patienceBarFill; // UI fill image for patience bar
    [SerializeField] private float maxPatience = 15f; // Total time before patience depletes
    [SerializeField] private float wrongItemPenalty = 3f; // Time deducted for wrong item
    private float patienceRemaining;
    private bool isRunning = false;
    
    [SerializeField] private BathGame bathGame; // Serialized for Inspector

    void Start()
    {
        ResetBathBar();
    }

    void Update()
    {
        if (isRunning)
        {
            patienceRemaining -= Time.deltaTime;
            UpdatePatienceUI();

            if (patienceRemaining <= 0)
            {
                TriggerGameOver();
            }
        }
    }

    public void StartBathBar()
    {
        isRunning = true;
        patienceRemaining = maxPatience;
        UpdatePatienceUI();
    }

    public void ReducePatience()
    {
        patienceRemaining -= wrongItemPenalty;
        if (patienceRemaining < 0) patienceRemaining = 0;
        UpdatePatienceUI();
    }

    private void UpdatePatienceUI()
    {
        if (patienceBarFill != null)
        {
            patienceBarFill.fillAmount = patienceRemaining / maxPatience;
        }
    }

    private void TriggerGameOver()
    {
        isRunning = false;
        if (bathGame != null)
        {
            bathGame.HandlePatienceDepleted();
        }
    }

    public void ResetBathBar()
    {
        patienceRemaining = maxPatience;
        isRunning = false;
        UpdatePatienceUI();
    }

    // New method to manually set the UI elements via Inspector
    public void InitializeBathBar(BathGame game, Image patienceBar)
    {
        bathGame = game;
        patienceBarFill = patienceBar;
    }
}
