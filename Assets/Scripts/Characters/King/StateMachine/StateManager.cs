using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public BaseState CurrentState { get; private set; }
    
    public IdleState IdleState;
    public ChaseState ChaseState;
    public WalkState WalkState;
    public RunState RunState;

    private void Start()
    {
        //idleState = gameObject.AddComponent(typeof(IdleState)) as IdleState;
        IdleState = new IdleState(this);
        ChaseState = new ChaseState(this);
        WalkState = new WalkState(this);
        RunState = new RunState(this);
        SwitchState(IdleState);

    }

    public void SwitchState(BaseState state)
    {
        print(state);
        CurrentState = state;
        CurrentState.StartState(gameObject);
        
    }
}
