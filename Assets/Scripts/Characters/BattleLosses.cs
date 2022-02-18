using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BattleLosses
{
    public int Infantry;
    public int Archers;
    public int Cavalry;

    public int AllLosses()
    {
        return Infantry + Archers + Cavalry;
    }
}
