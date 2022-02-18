using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleManager : BattleManger
{
    
    
    public  override void Battle(Squad firstSquad,Squad secondSquad,out BattleLosses firstArmyLosses,out BattleLosses secondArmyLosses ) 
    {
        
        _firstArmy = firstSquad.Army;
        _secondArmy = secondSquad.Army;

        
        Losses(_firstArmy,_secondArmy,out firstArmyLosses,out secondArmyLosses);
        _firstArmy.Losses(firstArmyLosses);
        _secondArmy.Losses(secondArmyLosses);
        
        if (_firstArmy.GetAllDamage - _secondArmy.GetAllHealth > 0)
        {
            firstSquad.Dialog.Win(firstArmyLosses);
            firstSquad.MoneyManger.Money += secondArmyLosses.AllLosses();
        }
        else
        {
            firstSquad.Dialog.Lose(firstArmyLosses);
            firstSquad.MoneyManger.Money -= firstArmyLosses.AllLosses();
        }
        

    }
    
    

}
