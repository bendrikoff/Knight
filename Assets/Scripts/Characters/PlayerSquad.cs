using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSquad :Squad
{
    public override int Warriors{get;set;}

    protected override void InitBehaviours()
    {

    }
    
    private void Start() 
    {
        InitBehaviours();
    }
    private void Update() 
    {
        
    }


}
