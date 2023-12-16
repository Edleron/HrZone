using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent == null)
        {
            // E�er NavMeshAgent bile�eni eklenmemi�se, bir hata mesaj� yazd�r
            Debug.LogError("NavMeshAgent component not found on the Player game object.");
        }
    }

    void Update()
    {
        // Sol fare tu�una t�klama kontrol� yap
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
}
