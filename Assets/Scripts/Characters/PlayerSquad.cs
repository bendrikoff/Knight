using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSquad :Squad
{
    public override int Warriors{get;set;}
    public override int Speed{get;protected set;}
    public override Army Army { get; set; }


    protected override void InitBehaviours()
    {

    }
    
    private void Start() 
    {
        InitBehaviours();
        Army = GetComponent<Army>();
    }
    private void Update() 
    {
        
    }


}
