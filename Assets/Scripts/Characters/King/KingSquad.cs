using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingSquad : Squad
{

    [SerializeField]
    private string name;

    public Text NameText;
    
    public override string Name
    {
        get => name;
        set => name = value;
    }

    public override int Warriors{get;set;}
    public override Army Army { get; set; }
    
    public BattleManger BattleManger { get; set; }

    public StateManager StateManager;

    public override Relation Relation { get; set; }
    public override int Speed
    {
        get => _speed;
        protected set => _speed = value;
    }
    
    
    private GameObject _player;
    private PlayerSquad _playerSquad;
    private int _speed;

    void Start() {
        InitBehaviours();
        _player = GameObject.FindWithTag("Player");
        _playerSquad = _player.GetComponent<PlayerSquad>();

        StateManager = GetComponent<StateManager>();
        Army = GetComponent<Army>();

        ChangeName();
        Army.ChangeWarriors += ChangeName;
        Speed = 50;
    }

    private void Update()
    {
        
        Moveable.Move(_playerSquad);
    }

    protected override void InitBehaviours()
    {
        Relation = Relation.enemy;
        Moveable= gameObject.AddComponent(typeof(KingMoveBehaviour)) as KingMoveBehaviour;
        
        Dialog= gameObject.AddComponent(typeof(KingDialogBehaviour)) as KingDialogBehaviour;

        

    }

    public void ChangeName()
    {
        NameText.text = name + "(" + Army.GetAllWarriors() + ")";
    }

}
