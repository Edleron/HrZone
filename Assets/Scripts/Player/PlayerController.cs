using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;
    private bool isInput = false;
    private Vector3 setOneAttack = new Vector3(-26, 2.1f, 1);
    private Vector3 setTwoAttack = new Vector3(3, 2, 2);
    
    private int setTrans = 0;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent == null)
        {
            
            Debug.LogError("NavMeshAgent component not found on the Player game object.");
        }
    }

    void Update()
    {
        if (isInput) return;

        if (Input.GetMouseButtonDown(0))
        {
            // Mouse pozisyonunu al
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            // Raycast kullanarak t�klanan noktan�n ge�erli bir yere olup olmad���n� kontrol et
            if (Physics.Raycast(ray, out hit))
            {
                 agent.SetDestination(hit.point);
            }
        }
    }

    public void transactionStart(){
        if (setTrans < 3) setTrans++;
        agent.enabled = false;
        if (setTrans == 1) this.transform.position = setOneAttack;
        if (setTrans == 2) this.transform.position = setTwoAttack;
        agent.enabled = true;
    }

    public void setInputTrue(){
        isInput = true;
    }

    public void setInputFalse(){
        isInput = false;
    }
}
