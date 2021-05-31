using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Squad : MonoBehaviour
{
    protected IMoveable _moveable;
    protected Relate _relate;

    public enum Relate{
        enemy,neutral,friendly
    }

    protected abstract void InitBehaviours();

    public virtual void SetRelate(Relate relate){
        _relate=relate;
    }

    public virtual Relate GetRelate(){
        return _relate;
    }





}
