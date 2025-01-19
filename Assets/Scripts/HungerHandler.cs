using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class HungerHandler : MonoBehaviour
{
    [SerializeField] float Hunger = 100f;
    [SerializeField] private float CurrentHunger = 100f;
    [SerializeField] private float AmountChanged = .5f;
    [SerializeField] private float HungerTimer = 60f;
    [SerializeField] private UnityEngine.UI.Slider HungerSlider;
    private float timer = 0f;

    private void Start()
    {
        HungerSlider.maxValue = Hunger;
        HungerSlider.minValue = 0f;
        HungerSlider.value = CurrentHunger;
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
        }
        
    }

    public void SatiateHunger(float FoodAmount)
    {
        CurrentHunger += FoodAmount;
        if((CurrentHunger - Hunger) > .01f)
        {
            CurrentHunger = Hunger;
        }
        HungerSlider.value = CurrentHunger;
    }
}
