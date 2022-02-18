using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class KingMoveBehaviour : MonoBehaviour,IMoveable
{
    private KingSquad _thisSquad;
    private Relation _relation;
    private StateManager _stateManager;
    
    
    private void Start()
    {
        _thisSquad = GetComponent<KingSquad>();
        _stateManager = GetComponent<StateManager>();
        _relation = _thisSquad.Relation;
    }

    public void Move(Squad target)
    {
        _stateManager.CurrentState.Move(target,_thisSquad.Speed);
    }

   

}
