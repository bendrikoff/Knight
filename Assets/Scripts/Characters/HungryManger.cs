using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungryManger : MonoBehaviour
{
    public Text FoodText;
    
    public Text HungryText;
    
    public TimeManager TimeManager;
    public EventsMessages EventsMessages;
    
    private Army _army;

    public int Hungry
    {
        get => _army.GetAllHungry;
    }

    public int Food { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _army = GetComponent<Army>();
        Initialize();
        TimeManager.NextDay += DayChange;
        _army.ChangeWarriors += HungryTextChange;
    }

    // Update is called once per frame
    private void DayChange()
    {
        if (Food > Hungry)
        {
            Food -= Hungry;
        }
        else
        {
            Food = 0;
        }

        FoodText.text = Food.ToString();
    }

    private void HungryTextChange()
    {
        HungryText.text = "-" + Hungry;
    }

    private void Initialize()
    {
        FoodText.text = Food.ToString();
        HungryText.text = "-" + Hungry;
    }
}
