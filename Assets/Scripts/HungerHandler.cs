using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class HungerHandler : MonoBehaviour
{
    [SerializeField] float Hunger = 100f;
    [SerializeField] private float CurrentHunger = 100f;
    [SerializeField] private float AmountChanged = 3f;
    [SerializeField] private float HungerTimer = 10f;
    [SerializeField] private float acceleration = .1f;
    [SerializeField] private float acceleration2 = .05f;
    [SerializeField] private UnityEngine.UI.Slider HungerSlider;
    private FoodObject.FoodTypes FoodIWant;
    private float timer = 0f;
    private int score = 0;

    private void Start()
    {
        HungerSlider.maxValue = Hunger;
        HungerSlider.minValue = 0f;
        HungerSlider.value = CurrentHunger;
        FoodIWant = 
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > HungerTimer)
        {
            CurrentHunger -= AmountChanged;
            HungerSlider.value = CurrentHunger;
            timer = 0f;
            AmountChanged += acceleration;
            acceleration += acceleration2;
        }
        
    }

    public void SatiateHunger(float FoodAmount, int ScoreAmount)
    {
        CurrentHunger += FoodAmount;
        score += ScoreAmount;
        if((CurrentHunger - Hunger) > .01f)
        {
            CurrentHunger = Hunger;
        }
        HungerSlider.value = CurrentHunger;
    }
}
