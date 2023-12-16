using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent Enemyagent;
    [SerializeField] int state = 1;
    [SerializeField] Transform state1Point;
    [SerializeField] Transform state2Point;
    [SerializeField] Transform state3Point;

    void Start()
    {
        Enemyagent = GetComponent<NavMeshAgent>();

        if (Enemyagent == null)
        {
            // Eðer NavMeshAgent bileþeni eklenmemiþse, bir hata mesajý yazdýr
            Debug.LogError("NavMeshAgent component not found on the Player game object.");
        }
    }

    void Update()
    {
        if (state == 1)
            Enemyagent.SetDestination(state1Point.position);
        else if(state == 2)
            Enemyagent.SetDestination(state2Point.position);
        else
            Enemyagent.SetDestination(state3Point.position);
    }   

}

