using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public List<GameObject> Roads = new List<GameObject>();
    private int statePocess = 0;
    
    private void OnEnable()
    {
        EventManager.onLevelProcess += NextLevel;
    }

    private void OnDisable()
    {
        EventManager.onLevelProcess -= NextLevel;
    }

    private void Awake(){
        foreach (var item in Roads)
        {   
            item.SetActive(false);
        }
        Roads[statePocess].SetActive(true);
    }

    private void NextLevel(){
        if (statePocess < (Roads.Count-1)) statePocess++;
        Debug.Log(statePocess);
        Roads[statePocess].SetActive(true);
    }
}
