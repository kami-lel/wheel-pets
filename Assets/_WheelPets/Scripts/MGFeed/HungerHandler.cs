using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class HungerHandler : MonoBehaviour
{
    [SerializeField]
    float Hunger = 100f;

    [SerializeField]
    private float CurrentHunger = 40f;

    [SerializeField]
    private float AmountChanged = 1f;

    [SerializeField]
    private float HungerTimer = 1f;

    [SerializeField]
    private UnityEngine.UI.Slider HungerSlider;
    private FoodObject.FoodTypes FoodIWant;
    private float timer = 0f;
    private int score = 20;
    private FoodObject.FoodTypes[] foods = new FoodObject.FoodTypes[6];

    [SerializeField]
    private TMP_Text texty;

    [SerializeField]
    private TMP_Text textytoo;

    [SerializeField]
    private AudioSource FeedEffect;

    [SerializeField]
    private AudioSource BadFeedEffect;

    [SerializeField]
    private AudioSource Music;
    public PauseOverlay pauseOverlay;

    // At some point, a singleton needs to be coordinated + implemented so that this can just search for it by name. For now, I will initialize an object for it.
    [SerializeField]
    GameObject Spawner;

    private GameObject displayFood;

    private void Start()
    {
        Music.Play();
        HungerSlider.maxValue = Hunger;
        HungerSlider.minValue = 0f;
        HungerSlider.value = CurrentHunger;
        foods[0] = FoodObject.FoodTypes.Food1;
        foods[1] = FoodObject.FoodTypes.Food2;
        foods[2] = FoodObject.FoodTypes.Food3;
        foods[3] = FoodObject.FoodTypes.Food4;
        foods[4] = FoodObject.FoodTypes.Food5;
        foods[5] = FoodObject.FoodTypes.Food6;
        int bleh = Random.Range(
            0,
            Spawner.GetComponent<SpawnHandler>().NumPrefabs
        );
        FoodIWant = foods[bleh];
        texty.text = "I want...      !";
        displayFood = Instantiate(Spawner.GetComponent<SpawnHandler>().gameObjects[bleh], new Vector3(.62f, -4.54f, -1.5f), Quaternion.identity);
        displayFood.GetComponent<BoxCollider2D>().enabled = false;
        textytoo.text = "Foods Left: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > HungerTimer)
        {
            CurrentHunger -= AmountChanged;
            HungerSlider.value = CurrentHunger;
            timer = 0f;
        }
        if (
            CurrentHunger <= 0f
            && pauseOverlay.status == PauseOverlay.Status.Running
        )
        {
            pauseOverlay.MinigameLost();
            Data.GetPlayerData().statFeed.RecordWin((float)score);
        }
        if (score <= 0 && pauseOverlay.status == PauseOverlay.Status.Running)
        {
            pauseOverlay.MinigameWin();
            Data.GetPlayerData().statFeed.RecordWin((float)CurrentHunger);
        }
    }

    public void SatiateHunger(
        float FoodAmount,
        int ScoreAmount,
        FoodObject.FoodTypes foodType
    )
    {
        if (FoodIWant == foodType)
        {
            score -= ScoreAmount;
            FeedEffect.Play();
        }
        else
        {
            BadFeedEffect.Play();
        }
        if ((CurrentHunger - Hunger) > .01f)
        {
            CurrentHunger = Hunger;
        }
        HungerSlider.value = CurrentHunger;
        int bleh = Random.Range(
            0,
            Spawner.GetComponent<SpawnHandler>().NumPrefabs
        );
        FoodIWant = foods[bleh];
        texty.text = "I want...      !";
        Destroy(displayFood);
        displayFood = Instantiate(Spawner.GetComponent<SpawnHandler>().gameObjects[bleh], new Vector3(.62f, -4.54f, -1.5f), Quaternion.identity);
        displayFood.GetComponent<BoxCollider2D>().enabled = false;
        Spawner.GetComponent<SpawnHandler>().ResetFoods();
        textytoo.text = "Foods Left: " + score.ToString();
    }
}
