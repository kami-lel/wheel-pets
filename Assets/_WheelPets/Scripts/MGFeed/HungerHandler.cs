using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HungerHandler : MonoBehaviour
{
    [SerializeField]
    float Hunger = 100f;

    [SerializeField]
    private float CurrentHunger = 100f;

    [SerializeField]
    private float AmountChanged = 3f;

    [SerializeField]
    private float HungerTimer = 10f;

    [SerializeField]
    private float acceleration = .1f;

    [SerializeField]
    private float acceleration2 = .05f;

    [SerializeField]
    private UnityEngine.UI.Slider HungerSlider;
    private FoodObject.FoodTypes FoodIWant;
    private float timer = 0f;
    private int score = 0;
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
        texty.text = "I want... " + (bleh + 1).ToString() + "!";
        textytoo.text = "Score: " + score.ToString();
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
            AmountChanged += acceleration;
            acceleration += acceleration2;
        }
        if (
            CurrentHunger <= 0f
            && pauseOverlay.status == PauseOverlay.Status.Running
        )
        {
            pauseOverlay.MinigameLost();
            Data.GetPlayerData().statFeed.RecordWin((float)score);
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
            CurrentHunger += FoodAmount;
            score += ScoreAmount;
            FeedEffect.Play();
        }
        else
        {
            CurrentHunger -= FoodAmount;
            score -= ScoreAmount;
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
        texty.text = "I want... " + (bleh + 1).ToString() + "!";
        Spawner.GetComponent<SpawnHandler>().ResetFoods();
        textytoo.text = "Score: " + score.ToString();
    }
}
