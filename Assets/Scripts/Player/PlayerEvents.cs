using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("SETLEVEL"))
       {
            // Bir nesne trigger alanından çıktığında bu kod çalışır
            // Debug.Log(other.name + " has exited the trigger zone.");
            EventManager.Fire_onGameTriggerEnter(other.name);
       }
    }

    private void OnTriggerExit(Collider other)
    {
       if (other.CompareTag("SETLEVEL"))
       {
            // Bir nesne trigger alanından çıktığında bu kod çalışır
            // Debug.Log(other.name + " has exited the trigger zone.");
            EventManager.Fire_onGameTriggerExit(other.name);
       }
    }
}
