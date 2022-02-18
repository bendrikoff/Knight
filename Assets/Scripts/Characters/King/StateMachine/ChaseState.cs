using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseState
{
    public override event Action<Squad> MeetSquad;

    private KingSquad _kingSquad=>_thisSquad.GetComponent<KingSquad>();
    
    
    
    public ChaseState(StateManager stateManager)
    {
        StateManager = stateManager;
    }
    public override void Move(Squad target, int speed)
    {
        //if (Vector3.Distance(target.transform.position, _currentPoint) < KingSettings.RadiusToDialog) _kingSquad.Dialog.Dialog(_thisSquad,target);

        if (Vector3.Distance(target.transform.position, _currentPoint) < KingSettings.RadiusToDialog)
        {
            MeetSquad += target.Dialog.Dialog;
            MeetSquad?.Invoke(_kingSquad);
        }
        
        if (Vector3.Distance(target.transform.position, _currentPoint) > KingSettings.RadiusToChase) StateManager.SwitchState(StateManager.IdleState);
        MoveTo(target.transform.position,speed);
    }


}
