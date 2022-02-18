using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogBehaviour : MonoBehaviour,IDialog
{
    public GameObject DialogPanel;

    private DialogPanel _dialogPan;

    private void Start()
    {
        _dialogPan = DialogPanel.GetComponent<DialogPanel>();
    }

    public void Dialog(Squad target)
    {
        _dialogPan.Open();
        _dialogPan.EnemyDialog(target);
        target.Kick(200);
    }
    
    

    public void Win(BattleLosses battleLosses)
    {
        _dialogPan.OpenWinPan(battleLosses);
        
    }

    public void Lose(BattleLosses battleLosses)
    {
        _dialogPan.OpenLosePan(battleLosses);
    }
}
