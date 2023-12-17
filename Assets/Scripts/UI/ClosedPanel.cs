using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedPanel : MonoBehaviour
{
    public void ClosedInfoPanel(){
        EventManager.Fire_UITriggerClosed("Closed");
    }
}
