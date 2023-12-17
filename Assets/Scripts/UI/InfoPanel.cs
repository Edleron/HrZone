using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoPanel : MonoBehaviour
{
    public List<string> infoText = new List<string>();
    private int index = 0;
    private TextMeshProUGUI textMesh; 

    private void OnEnable()
    {
        EventManager.onLevelProcess += ChangeText;
    }

    private void OnDisable()
    {
        EventManager.onLevelProcess -= ChangeText;
    }

    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
         textMesh.text = infoText[0];
    }

    private void ChangeText()
    {
        index++;
        try
        {
            string newText = infoText[index];
            if (textMesh != null)
            {
                textMesh.text = newText;
            }
            else
            {
                Debug.LogError("Text Mesh Pro bileşeni atanmamış!");
            }
        }
        catch (System.Exception ex)
        {
             // TODO
        }
        
    }
}
