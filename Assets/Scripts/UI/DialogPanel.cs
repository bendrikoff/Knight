using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogPanel : MonoBehaviour
{
    public Text WelcomeText;

    public Text firstButtonText;
    public Text secondButtonText;
    
    [Header("PopUp")]
    public GameObject popUp;
    public Text popUpText;

    [Header("Win Panel")]
    public GameObject WinPan;
    public Text Losses;
    
    [Header("Lose Panel")]
    public GameObject LosePan;
    public Text Losses2;
    
    private PlayerSquad _playerSquad;
    private Squad _dialogSquad;

    private GameObject _player;
    
    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _playerSquad = _player.GetComponent<PlayerSquad>();
    }

    public void Open()
    {
        StartDialog();
        gameObject.SetActive(true);
    }
    
    
    //Сделать генерацию кнопок
    public void EnemyDialog(Squad dialogSquad)
    {
        _dialogSquad = dialogSquad;
        WelcomeText.text = "Ну здарова, пидар";
        //WelcomeText.text = enemySquad.name;


    }

    public void BattleBtnn()
    {
        var playerArmyLosses = new BattleLosses();
        var dialogSquadArmyLosses = new BattleLosses();
        _playerSquad.BattleManger.Battle(_playerSquad,_dialogSquad,out playerArmyLosses,out dialogSquadArmyLosses);
    }


    public void GiveMoney()
    {
        if (_playerSquad.MoneyManger.Pay(200))
        {
            gameObject.SetActive(false);

            _dialogSquad.Kick(200);
        }
        
    }

    public void OpenPopUp(string str)
    {
        StartDialog();
        popUp.SetActive(true);
        popUpText.text = str;
    }

    public void ClosePopUp()
    {
        CloseDialog();
        popUp.SetActive(false);
    }

    public void OpenWinPan(BattleLosses losses)
    {
        StartDialog();
        gameObject.SetActive(false);
        WinPan.SetActive(true);
        Losses.text = losses.AllLosses().ToString();
    }

    public void CloseWinPan()
    {
        CloseDialog();
        WinPan.SetActive(false);
    }

    public void OpenLosePan(BattleLosses losses)
    {
        StartDialog();
        gameObject.SetActive(false);
        LosePan.SetActive(true);
        Losses2.text = losses.AllLosses().ToString();
    }
    
    public void CloseLosePan()
    {
        CloseDialog();
        LosePan.SetActive(false);
    }
    private void CloseDialog()
    {
        TimeManager.GetInstance().StartTime();
    }

    private void StartDialog()
    {
        TimeManager.GetInstance().StopTime();
    }
}
