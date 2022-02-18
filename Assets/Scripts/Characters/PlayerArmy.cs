// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class PlayerArmy : Army
// {
//     public GameObject ResoursesPanGO;
//
//     private ResoursesPan ResoursesPan;
//     
//     public override int Infantry
//     {
//        set
//         {
//             if (value < 0)
//             {
//                 _infantry = 0;
//             }
//             else
//             {
//                 _infantry = value;
//             }
//             ResoursesPan.WarriorsChange(GetAllWarriors());
//         }
//     }
//
//     public override int Archers
//     {
//         set
//         {
//             if (value < 0)
//             {
//                 Archers = 0;
//             }else
//             {
//                 _archers = value;
//             }
//             ResoursesPan.WarriorsChange(GetAllWarriors());
//         } 
//     }
//     public override int Cavalry
//     { 
//         set
//         {
//             if (value < 0)
//             {
//                 Cavalry = 0;
//             }else
//             {
//                 _cavalry = value;
//             }
//             ResoursesPan.WarriorsChange(GetAllWarriors());
//         }
//         
//     }
//
//     private void Start()
//     {
//         _armyStats = new ArmyStats();
//         ResoursesPan = ResoursesPanGO.GetComponent<ResoursesPan>();
//         //ResoursesPan.WarriorsChange(GetAllWarriors());
//         Infantry=50;
//     }
//
// }
