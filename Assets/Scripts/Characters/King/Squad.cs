using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Squad : MonoBehaviour
{
    public abstract string Name { get; set; }
    
    public virtual MoneyManger MoneyManger { get; set; }
    public abstract int Warriors { get; set; }

    public abstract Army Army { get; set; }

    public virtual StateManager StateManager { get; set; }
    public virtual BattleManger BattleManger { get; set; }

    public virtual Relation Relation{ get; set; }
    
    //Создать отдельный класс под статы Stats, KingsStats для ScriptableObject
    public abstract int Speed { get; protected set; }

    protected IMoveable Moveable;
    public IDialog Dialog;
    
    protected abstract void InitBehaviours();
    
    //Отбросить сквад
    public virtual void Kick(int force)
    {
        transform.position = new Vector2(transform.position.x + force, transform.position.y);
    }







}
