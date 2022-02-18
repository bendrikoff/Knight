using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected StateManager StateManager;
    
    protected GameObject _thisSquad;
    protected virtual Vector3 _currentPoint => _thisSquad.transform.position;

    public virtual event Action<Squad> MeetSquad;

    public abstract void Move(Squad target,int speed);
    //public abstract void StartState(GameObject thisSquad);

    protected void MoveTo(Vector3 targetPoint,int speed)
    {
        var destination = new Vector3(targetPoint.x, _currentPoint.y,  targetPoint.z);
        var step = 2f * Time.deltaTime * speed;
        _thisSquad.transform.position = Vector3.MoveTowards(_currentPoint, destination, step);
    }
    public virtual void StartState(GameObject thisSquad)
    {
        _thisSquad = thisSquad;
    }
    
}
