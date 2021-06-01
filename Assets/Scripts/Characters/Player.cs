using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player :Squad
{
    
    protected override void InitBehaviours()
    {
        _moveable = new PlayerMoveBehaviour(gameObject);
    }
    
    private void Start() 
    {
        InitBehaviours();
    }
    private void Update() 
    {
        _moveable.Move();
    }


}
