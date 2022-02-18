using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactoryManager : MonoBehaviour
{
    private List<Factory> _factoriesBought;

    private MoneyManger _moneyManger;

    private void Start()
    {
        _moneyManger = GetComponent<MoneyManger>();
        _factoriesBought = new List<Factory>();
    }

    public void AddFactory(Factory factory)
    {
        factory.LevelReset();
        _factoriesBought.Add(factory);
        _moneyManger.MoneyChange += factory.Income; 
    }

    public void LoseFactory(Factory factory)
    {
       
        _factoriesBought.Remove(factory);
        _moneyManger.MoneyChange -= factory.Income; 
        factory.LevelReset();

    }

    public void UpgradeFactory(Factory factory)
    {
        factory.LevelUp();
    }
}
