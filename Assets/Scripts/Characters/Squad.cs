using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Squad : MonoBehaviour
{
    public abstract int Warriors{get;set;}
    protected IMoveable _moveable;
    protected IDialog _dialog;
    protected virtual Relation _relation{get;set;}
    

    protected abstract void InitBehaviours();







}
