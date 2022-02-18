using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Army : MonoBehaviour
{
    public virtual Action ChangeWarriors { get; set; }

    protected int _infantry;
    public virtual int Infantry
    {
        get => _infantry;
        set
        {
            if (value < 0)
            {
                _infantry = 0;
            }
            else
            {
                _infantry = value;
            }
            ChangeWarriors?.Invoke();
        }
    }

    protected int _archers;
    public virtual int Archers
    { 
        get => _archers;
        set
        {
            if (value < 0)
            {
                _archers = 0;
            }else
            {
                _archers = value;
            }
            ChangeWarriors?.Invoke();
        } 
    }
    
    protected int _cavalry;
    public virtual int Cavalry
    {        
        get => _cavalry;
        set
        {
            if (value < 0)
            {
                _cavalry = 0;
            }else
            {
                _cavalry = value;
            }
            ChangeWarriors?.Invoke();
        }
        
    }

    protected ArmyStats _armyStats;
    
    private GeneralArmyStats _generalArmyStats;

    private bool _desertearing;
    
    // public int GetAllDamage => _armyStats.InfantryDamage*Infantry + _armyStats.ArchersDamage*Archers + _armyStats.CavalryDamage*Cavalry;
    // public int GetAllHealth=> _armyStats.InfantryHealth*Infantry + _armyStats.CavalryHealth*Archers + _armyStats.ArchersHealth*Cavalry;
    public int GetAllDamage => _armyStats.InfantryDamage*Infantry + _armyStats.ArchersDamage*Archers + _armyStats.CavalryDamage*Cavalry;
    public int GetAllHealth=> _armyStats.InfantryHealth*Infantry + _armyStats.CavalryHealth*Archers + _armyStats.ArchersHealth*Cavalry;
    public int GetAllWarriors() => Infantry + Archers + Cavalry;
    public int GetAllSalary=>Infantry*_generalArmyStats.InfantrySalary+Archers*_generalArmyStats.ArchersSalary+Cavalry*_generalArmyStats.CavalrySalary;
    public int GetAllHungry=>Infantry*_generalArmyStats.InfantryHungry+Archers*_generalArmyStats.ArchersHungry+Cavalry*_generalArmyStats.CavalryHungry; 

    public int GetInfantryDamage() => _armyStats.InfantryDamage;
    public int GetArchersDamage() => _armyStats.ArchersDamage;
    public int GetCavalryDamage() => _armyStats.CavalryDamage;
    
    private void Start()
    {
        _armyStats = new ArmyStats();
        _generalArmyStats = GetComponent<GeneralArmyStats>();
    }

    public void Losses(BattleLosses losses)
    {
        Infantry -= losses.Infantry;
        Archers -= losses.Archers;
        Cavalry -= losses.Cavalry;
    }

    public void Desertearing()
    {
        if (Infantry > 0)
        {
            Infantry -= 1;
        }
        else if(Archers>0)
        {
            Archers -= 1;
        }else if (Cavalry > 0)
        {
            Cavalry -= 1;
        }
    }

}
