using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public List<GameObject> Info = new List<GameObject>();
    public GameObject CompletedPanel;
    public GameObject EditörPanelPanel;
    private int statePocess = 0;

    private LevelManager levelManager;
    
    private void Awake(){
        CompletedPanel.SetActive(false);
        EditörPanelPanel.SetActive(false);
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
        EventManager.onOpenCodePanel += OpenEditorPanelX;
    }

    private void OnDisable()
    {
        EventManager.UITriggerOpen -= OpenPanel;
        EventManager.UITriggerClosed -= ClosedPanel;
        EventManager.onLevelProcess -= CompletedFalse;
        EventManager.onOpenCodePanel -= OpenEditorPanelX;
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
        if (statePocess == (Info.Count -1)) Diffuse.Instance.StartDiffuseAnim();
    }

    private void CompletedFalse(){
        CompletedPanel.SetActive(false);
    }

    private void OpenEditorPanelX(){
        EditörPanelPanel.SetActive(true);
    }
}
