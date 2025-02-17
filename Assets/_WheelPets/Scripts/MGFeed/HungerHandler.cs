using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HungerHandler : MonoBehaviour
{
    [SerializeField] float Hunger = 100f;
    [SerializeField] private float CurrentHunger = 100f;
    [SerializeField] private float AmountChanged = 3f;
    [SerializeField] private float HungerTimer = 10f;
    [SerializeField] private float acceleration = .1f;
    [SerializeField] private float acceleration2 = .05f;
    [SerializeField] private Slider HungerSlider;
    private FoodObject.FoodTypes FoodIWant;
    private float timer = 0f;
    private int score = 0;
    private FoodObject.FoodTypes[] foods = new FoodObject.FoodTypes[6];
    [SerializeField] private TMP_Text texty;
    [SerializeField] private TMP_Text textytoo;
    [SerializeField] private AudioSource audo;
    [SerializeField] private AudioSource audo2;
    [SerializeField] private LocalizedGameText localizedGameText; // Reference to the LocalizedGameText script

    [SerializeField] GameObject Spawner;
    private void Start()
    {
        HungerSlider.maxValue = Hunger;
        HungerSlider.minValue = 0f;
        HungerSlider.value = CurrentHunger;
        foods[0] = FoodObject.FoodTypes.Food1;
        foods[1] = FoodObject.FoodTypes.Food2;
        foods[2] = FoodObject.FoodTypes.Food3;
        foods[3] = FoodObject.FoodTypes.Food4;
        foods[4] = FoodObject.FoodTypes.Food5;
        foods[5] = FoodObject.FoodTypes.Food6;
        int bleh = Random.Range(0, Spawner.GetComponent<SpawnHandler>().NumPrefabs);
        FoodIWant = foods[bleh];
        localizedGameText.UpdateWantText(bleh); // Update the localized want text
        localizedGameText.UpdateScoreText(); // Update the localized score text
    }

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
    }

    public void SatiateHunger(float FoodAmount, int ScoreAmount, FoodObject.FoodTypes foodType)
    {
        if (FoodIWant == foodType)
        {
            CurrentHunger += FoodAmount;
            score += ScoreAmount;
            localizedGameText.IncrementScore(ScoreAmount); // Update the localized score text
            audo.Play();
        }
        else
        {
            CurrentHunger -= FoodAmount;
            score -= ScoreAmount;
            localizedGameText.IncrementScore(-ScoreAmount); // Update the localized score text
            audo2.Play();
        }
        if ((CurrentHunger - Hunger) > .01f)
        {
            CurrentHunger = Hunger;
        }
        HungerSlider.value = CurrentHunger;
        int bleh = Random.Range(0, Spawner.GetComponent<SpawnHandler>().NumPrefabs);
        FoodIWant = foods[bleh];
        localizedGameText.UpdateWantText(bleh); // Update the localized want text
        Spawner.GetComponent<SpawnHandler>().ResetFoods();
    }
}
