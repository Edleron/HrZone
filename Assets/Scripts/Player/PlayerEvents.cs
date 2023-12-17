using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
   private string trigObject = "";

   private void OnEnable()
   {
        EventManager.onLevelProcess += OnCompleted;
   }

    private void OnDisable()
   {
        EventManager.onLevelProcess -= OnCompleted;
   }

    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("SETMİNİ"))
       {
            trigObject = other.name;
            EventManager.Fire_UITriggerOpen(other.name);
            this.gameObject.GetComponent<PlayerController>().setInputTrue();
       }

       if(other.CompareTag("SETLEVEL"))
       {
          EventManager.Fire_onLevelProcess();
          this.gameObject.GetComponent<PlayerController>().transactionStart();
       }

       if (other.CompareTag("SETBOSS"))
       {
            trigObject = other.name;
            EventManager.Fire_UITriggerOpen(other.name);
            this.gameObject.GetComponent<PlayerController>().setInputTrue();
       }
    }

    private void OnTriggerExit(Collider other)
    {
       if (other.CompareTag("SETMİNİ"))
       {
            EventManager.Fire_onGameTriggerExit(other.name);
            this.gameObject.GetComponent<PlayerController>().setInputFalse();
       }
    }

    private void OnCompleted()
    {
         this.gameObject.GetComponent<PlayerController>().setInputFalse();
         GameObject destObject =  GameObject.Find(trigObject);
         EventManager.Fire_onGameTriggerExit(trigObject);
         Destroy(destObject);
    }
}
