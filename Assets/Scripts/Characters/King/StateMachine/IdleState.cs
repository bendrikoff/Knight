using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public IdleState(StateManager stateManager)
    {
        StateManager = stateManager;
    }
    public override void Move(Squad target, int speed)
    {
        //StateManager.SwitchState(StateManager.WalkState);

        if (Vector2.Distance(_currentPoint, target.transform.position) < KingSettings.RadiusToChase)
        {
            if (_thisSquad.GetComponent<Squad>().Army.GetAllHealth < target.Army.GetAllDamage)
            {
                StateManager.SwitchState(StateManager.RunState); 
            }
            else
            {
                StateManager.SwitchState(StateManager.ChaseState);

            }
            
        }
        else
        {
            StateManager.SwitchState(StateManager.WalkState);
        }
    }

    // public override void StartState(GameObject thisSquad)
    // {
    //     _thisSquad = thisSquad;
    // }
    
}
