using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResoursesPan : MonoBehaviour
{
    public Army Army;
    
    public Text CoinsText;
    public Text MeatText;
    public Text WarriorsText;

    private void Start()
    {
        Army.ChangeWarriors += WarriorsChange;
        WarriorsChange();
    }

    public void CoinsChange()
    {
    }

    public void MeatChange()
    {
    }

    public void WarriorsChange()
    {
        WarriorsText.text = Army.GetAllWarriors().ToString();
    }
}
