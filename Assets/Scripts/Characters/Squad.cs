using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Squad : MonoBehaviour
{
    protected IMoveable _moveable;
    protected virtual Relation _relation{get;set;}
    

    protected abstract void InitBehaviours();







}
