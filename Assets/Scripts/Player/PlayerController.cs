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
            // Eðer NavMeshAgent bileþeni eklenmemiþse, bir hata mesajý yazdýr
            Debug.LogError("NavMeshAgent component not found on the Player game object.");
        }
    }

    void Update()
    {
        // Sol fare tuþuna týklama kontrolü yap
        if (Input.GetMouseButtonDown(0))
        {
            // Mouse pozisyonunu al
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            // Raycast kullanarak týklanan noktanýn geçerli bir yere olup olmadýðýný kontrol et
            if (Physics.Raycast(ray, out hit))
            {
                 agent.SetDestination(hit.point);
            }
        }
    }
}
