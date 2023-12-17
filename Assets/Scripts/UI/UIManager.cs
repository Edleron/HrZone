using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public List<GameObject> Info = new List<GameObject>();
    private int statePocess = 0;

    private LevelManager levelManager;
    
    private void Awake(){
        levelManager = this.gameObject.GetComponent<LevelManager>();

        foreach (var item in Info)
        {   
            item.SetActive(false);
        }
        Info[statePocess].SetActive(true);
    }

    private void OnEnable()
    {
        EventManager.UITriggerOpen += OpenPanel;
        EventManager.UITriggerClosed += ClosedPanel;
    }

    private void OnDisable()
    {
        EventManager.UITriggerOpen -= OpenPanel;
        EventManager.UITriggerClosed -= ClosedPanel;
    }

    private void OpenPanel(string dummy){
        Debug.Log(dummy);
        Info[statePocess].SetActive(true);
        EventManager.Fire_onGameTriggerEnter(dummy);
    }

    private void ClosedPanel(string dummy){
        Info[statePocess].SetActive(false);
        statePocess++;
    }
}
