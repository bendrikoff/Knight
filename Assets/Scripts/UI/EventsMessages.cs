using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventsMessages : MonoBehaviour
{
   public GameObject MessagePref;

   public float Time=1;
   
   public void SendYellowMessage(string str)
   {
      var content = transform.GetChild(0);
      var msg=Instantiate(MessagePref, content, true);
      var text = msg.GetComponent<Text>();
      text.text = str;
      text.color = new Color(255, 255, 0);


      StartCoroutine(DestroyMsg(msg));
   }
   public void SendRedMessage(string str)
   {
      var content = transform.GetChild(0);
      var msg=Instantiate(MessagePref, content, true);
      var text = msg.GetComponent<Text>();
      text.text = str;
      text.color = new Color(255, 0, 0);


      StartCoroutine(DestroyMsg(msg));
   }
   public void SendGreenMessage(string str)
   {
      var content = transform.GetChild(0);
      var msg=Instantiate(MessagePref, content, true);
      var text = msg.GetComponent<Text>();
      text.text = str;
      text.color = new Color(0, 255, 0);


      StartCoroutine(DestroyMsg(msg));
   }

   IEnumerator DestroyMsg(GameObject msg)
   {
      yield return new WaitForSeconds(Time);
      Destroy(msg);
   }
}
