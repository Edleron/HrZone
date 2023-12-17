using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedPanel : MonoBehaviour
{
   public void CompletedLevel(){
        EventManager.Fire_onLevelProcess();
   }
}
