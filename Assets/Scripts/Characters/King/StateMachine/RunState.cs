using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : BaseState

{
    protected override Vector3 _currentPoint { get;}
 
    public RunState(StateManager stateManager)
    {
        StateManager = stateManager;
    }
    public override void Move(Squad target, int speed)
    {
        if (Vector3.Distance(target.transform.position, _currentPoint) > KingSettings.RadiusToChase) StateManager.SwitchState(StateManager.IdleState);

        MoveTo(-target.gameObject.transform.position,speed);
    }

    // public override void StartState(GameObject thisSquad)
    // {
    //     _thisSquad = thisSquad;
    // }
}
