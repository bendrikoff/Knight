using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : BaseState
{
    // private GameObject _thisSquad;
    // //protected override  Vector3 _currentPoint => _thisSquad.transform.position;
    //
     private Vector3 _targetPoint;

    
    public WalkState(StateManager stateManager)
    {
        StateManager = stateManager;
    }
    public override void Move(Squad target, int speed)
    {
        if (Vector2.Distance(_targetPoint, _currentPoint) < 0.01f)
        {
            StateManager.SwitchState(StateManager.IdleState);
            return;
        }

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
            return;
        }
        MoveTo(_targetPoint,speed);

    }

    public override void StartState(GameObject thisSquad)
    {
        _thisSquad = thisSquad;
        _targetPoint = RandomPoint();
    }

    private Vector3 RandomPoint()
    {
        float x = Random.Range(_currentPoint.x - 200, _currentPoint.x + 200);
        float y = Random.Range(_currentPoint.y - 200, _currentPoint.y + 200);
        return new Vector3(x,0, y);
    }
}
