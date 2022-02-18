using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingDialogBehaviour : MonoBehaviour,IDialog
{
   public GameObject DialogPanel { get; set; }
   
   private GameObject _targetSquadGO;
   private Squad _targetSquad => _targetSquadGO.GetComponent<Squad>();

   private Squad _thisSquad => GetComponent<Squad>();



   public void Dialog(Squad target)
   {
      print("Я враг");
   }
   
   public void Win(BattleLosses battleLosses)
   {
      
   }
   public void Lose(BattleLosses battleLosses)
   {
      
   }

}
