using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent navAgent;
    public Transform[] walkpoints;
    private int walkIndex;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (navAgent.remainingDistance <=0.5f)
        {
            navAgent.isStopped = false;
        
            navAgent.SetDestination(walkpoints[walkIndex].position);
            anim.SetBool("isMoving", true);
            if (walkIndex == walkpoints.Length - 1)
            {
                walkIndex=0;
            }
            else
            {
                walkIndex ++;
            }
        }

        
    }
}
