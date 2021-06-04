using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingSquad : Squad
{
    public override int Warriors{get;set;}
    protected override Relation _relation{get;set;}

    void Start() {
        InitBehaviours();
    }

    protected override void InitBehaviours()
    {
        _moveable= gameObject.AddComponent(typeof(KingMoveBehaviour)) as KingMoveBehaviour;
    }


}
