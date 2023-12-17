using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
   private string trigObject = "";

    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("SETMİNİ"))
       {
            // Bir nesne trigger alanından çıktığında bu kod çalışır
            // Debug.Log(other.name + " has exited the trigger zone.");
            // EventManager.Fire_onGameTriggerEnter(other.name);
            trigObject = other.name;
            EventManager.Fire_UITriggerOpen(other.name);
            Invoke("OnTimeSetLevel", 5);
       }

       if(other.CompareTag("SETLEVEL")){
         this.transform.position = new Vector3(-26, 2.1f, 1);
       }
    }

    private void OnTriggerExit(Collider other)
    {
       if (other.CompareTag("SETMİNİ"))
       {
            // Bir nesne trigger alanından çıktığında bu kod çalışır
            // Debug.Log(other.name + " has exited the trigger zone.");
            EventManager.Fire_onGameTriggerExit(other.name);
       }
    }

    private void OnTimeSetLevel(){
         EventManager.Fire_onLevelProcess();
         GameObject destObject =  GameObject.Find(trigObject);
         EventManager.Fire_onGameTriggerExit(trigObject);
         Destroy(destObject);
    }
}
