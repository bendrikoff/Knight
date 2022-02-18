using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleManger:MonoBehaviour
{
    protected virtual Army _firstArmy { get; set; }
    protected virtual Army _secondArmy { get; set; }

    public virtual void Battle(Squad firstSquad, Squad secondSquad, out BattleLosses firstArmyLosses,
        out BattleLosses secondArmyLosses)
    {
         firstArmyLosses = new BattleLosses();
         secondArmyLosses = new BattleLosses();
    }    
    public virtual void Battle(Squad firstSquad, Squad secondSquad)
    {
    }

    

    protected virtual void Losses(Army firstArmy, Army secondArmy,out BattleLosses firstArmyLosses,out BattleLosses secondArmyLosses)
    {
        firstArmyLosses = new BattleLosses();
        secondArmyLosses = new BattleLosses();

        firstArmyLosses.Infantry = Convert.ToInt32(Math.Round(secondArmy.Infantry / 2f));
        firstArmyLosses.Archers = Convert.ToInt32(Math.Round(secondArmy.Archers / 2f));
        firstArmyLosses.Cavalry = Convert.ToInt32(Math.Round(secondArmy.Cavalry / 2f));


        secondArmyLosses.Infantry = Convert.ToInt32(Math.Round(firstArmy.Infantry / 2f));
        secondArmyLosses.Archers = Convert.ToInt32(Math.Round(firstArmy.Archers / 2f));
        secondArmyLosses.Cavalry = Convert.ToInt32(Math.Round(firstArmy.Cavalry / 2f));
    }
    
    // private  void Lose(Squad firstSquad,Squad secondSquad)
    // {
    //     if (firstSquad is PlayerSquad)
    //     {
    //         firstSquad.Dialog.Lose();
    //     }
    //
    //     if (secondSquad is PlayerSquad)
    //     {
    //         firstSquad.Dialog.Lose();
    //     }
    //     
    // }
    //
    // private  void Win(Squad firstSquad,Squad secondSquad)
    // {
    //     if (firstSquad is PlayerSquad)
    //     {
    //         firstSquad.Dialog.Win();
    //     }
    //
    //     if (secondSquad is PlayerSquad)
    //     {
    //         firstSquad.Dialog.Win();
    //     }
    // }
}
