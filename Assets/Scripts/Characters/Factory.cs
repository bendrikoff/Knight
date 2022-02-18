using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory
{
    public FactoryTypes Type { get; private set; }

    public string City;
    
    public int Level { get; private set; }
    
    public int Income { get; private set; }

    private Dictionary<int, int> _levelIncome;

    public void LevelUp()
    {
        Level += 1;
    }

    public void LevelReset()
    {
        Level = 0;
    }


}

