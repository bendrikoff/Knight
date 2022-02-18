using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquadPanel : MonoBehaviour
{

    public Army Army;

    public Text Infantry;
    
    public Text Archers;
    
    public Text Cavalry;
    
    public void OpenSquadPanel()
    {
        Initialize();
        TimeManager.GetInstance().StopTime();
        gameObject.SetActive(true);
    }

    public void CloseSquadPanel()
    {
        TimeManager.GetInstance().StartTime();
        gameObject.SetActive(false);
    }

    private void Initialize()
    {
        Infantry.text = Army.Infantry.ToString();
        Archers.text = Army.Archers.ToString();
        Cavalry.text = Army.Cavalry.ToString();
    }

    public void AddWarriors(int index)
    {
        if (index == 0)
        {
            Army.Infantry += 10;

        }

        if (index == 1)
        {
            Army.Archers += 10;
        }

        if (index == 2)
        {
            Army.Cavalry += 10;
        }
        Initialize();
    }
    
    public void RemoveWarriors(int index)
    {
        if (index == 0)
        {
            Army.Infantry -= 10;
          
        }

        if (index == 1)
        {
            Army.Archers -= 10;
        }

        if (index == 2)
        {
            Army.Cavalry -= 10;
        }
        Initialize();
    }
}
