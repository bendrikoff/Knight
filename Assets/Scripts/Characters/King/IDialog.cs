using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDialog 
{
    void Dialog(Squad target);
    
    void Win(BattleLosses battleLosses);
    void Lose(BattleLosses battleLosses);
}
