using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public List<GameObject> Info = new List<GameObject>();
    public GameObject CompletedPanel;
    private int statePocess = 0;

    private LevelManager levelManager;
    
    private void Awake(){
        CompletedPanel.SetActive(false);
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
        EventManager.onLevelProcess += CompletedFalse;
    }

    private void OnDisable()
    {
        EventManager.UITriggerOpen -= OpenPanel;
        EventManager.UITriggerClosed -= ClosedPanel;
        EventManager.onLevelProcess -= CompletedFalse;
    }

    private void OpenPanel(string dummy){
        Debug.Log(dummy);
        Info[statePocess].SetActive(true);
        EventManager.Fire_onGameTriggerEnter(dummy);
    }

    private void ClosedPanel(string dummy){
        Info[statePocess].SetActive(false);
        if (statePocess != 0) CompletedPanel.SetActive(true);
        statePocess++;
    }

    private void CompletedFalse(){
        CompletedPanel.SetActive(false);
    }
}
