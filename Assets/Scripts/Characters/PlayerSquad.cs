using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSquad :Squad
{
    public EventsMessages EventsMessages;

    public TimeManager TimeManager;
    [SerializeField]
    private string name;
    
    public Text NameText;

    public override string Name
    {
        get => name;
        set
        {
            name = value;

        }
    }
    
    public override int Warriors{get;set;}
    public override int Speed{get;protected set;}
    public override Army Army { get; set; }

    public override MoneyManger MoneyManger { get; set; }
    
    public  HungryManger HungryManger { get; set; }


    protected override void InitBehaviours()
    {
        Dialog = GetComponent<PlayerDialogBehaviour>();
        BattleManger = GetComponent<BattleManger>();
        Army = GetComponent<Army>();
        MoneyManger = GetComponent<MoneyManger>();
        HungryManger = GetComponent<HungryManger>();
    }
    
    private void Start() 
    {
        InitBehaviours();
        ChangeName();

        Army.ChangeWarriors += ChangeName;
        TimeManager.NextDay += Desertearing;

    }
    public void ChangeName()
    {
        NameText.text = name + "(" + Army.GetAllWarriors() + ")";
    }

    private void Desertearing()
    {
        if (Army.GetAllWarriors() > 0)
        {
            if (MoneyManger.Money == 0 || HungryManger.Hungry == 0)
            {
                Army.Desertearing();
                if(MoneyManger.Money == 0) EventsMessages.SendRedMessage("У вас закончились деньги, ваши солдаты дезертируют");
                if(MoneyManger.Money == 0) EventsMessages.SendRedMessage("У вас закончилась еда, ваши солдаты дезертирую");
            }
        }
    }
    



}
