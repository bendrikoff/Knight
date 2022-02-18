using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManger : MonoBehaviour
{
    //Продумать, как изменять MOneyChange при добавлении воинов или при заработке
    public Text MoneyText;
    
    public Text MoneyChangeText;
    
    public DialogPanel DialogPanel;
    
    public TimeManager TimeManager;
    
    private Army _army;
    // public int Money
    // {
    //     get => _money;
    //     set
    //     {
    //         if (value <= 0)
    //         {
    //             _money = 0;
    //         }
    //
    //         else
    //         {
    //             _money = value;
    //         }
    //     }
    // }

    private int _moneyChange;

    public int MoneyChange
    {
        get => _moneyChange;

        set
        {
            _moneyChange = value;
            MoneyChangeTextUpdate();
        }
    } 
    
    private int _money;

    public int Money
    {
        get=>_money;
        set
        {
            if (value < 0)
            {
                _money = 0;
            }
            else
            {
                _money = value;
            }

            MoneyText.text = _money.ToString();
        }
    }

    private void Start()
    {
        _army = GetComponent<Army>();
        _army.ChangeWarriors += ChangeMoney;
        TimeManager.NextDay += DayChange;
        Initialize();

    }

    public bool Pay(int count)
    {
        if(_money<count)
        {
            DialogPanel.OpenPopUp("Недостаточно денег");
            return false;
        }
        DialogPanel.OpenPopUp("Ты заплатил "+count+" монет");
        _money -= count;
        return true;
    }
    
    private void DayChange()
    {
        Money += MoneyChange;
        
    }

    private void MoneyChangeTextUpdate()
    {
        if (MoneyChange < 0)
        {
            MoneyChangeText.text = MoneyChange.ToString();
            MoneyChangeText.color = new Color(255, 0, 0);
        }
        else
        {
            MoneyChangeText.text = "+" + MoneyChange.ToString();
            MoneyChangeText.color = new Color(0, 255, 0);
        }
    }

    private void ChangeMoney()
    {
        MoneyChange = -_army.GetAllSalary;
    }

    private void Initialize()
    {
        ChangeMoney();
        MoneyChangeTextUpdate();
        MoneyText.text = _money.ToString();
    }
}
