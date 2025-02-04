using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NaveMeshEnemy : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform PointerPlayer;
    public float LookRadius;
    public float LookRadiusDisparo;

    public Animator animatorEnemy;
    
    void Start()
    {
        animatorEnemy = GetComponentInChildren<Animator>();
    }    
    void Update()
    {
        MovimientoNavMesh();
    }

    public void MovimientoNavMesh()
    {
        float distancia = Vector3.Distance(PointerPlayer.position, transform.position);
        Debug.Log(distancia);

        if(distancia <= LookRadius)
        {
            FaceTarget();
            Agent.SetDestination(PointerPlayer.position);
            animatorEnemy.SetBool("Run", true);
            Agent.speed = 6f;

            if(distancia <= LookRadiusDisparo)
            {
                animatorEnemy.SetBool("Disparo", true);
                Agent.speed = 0f;
                
            }
            else
            {                
                animatorEnemy.SetBool("Disparo", false);
            }
        }
        else
        {
            animatorEnemy.SetBool("Run", false);
            Agent.speed = 0f;
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (PointerPlayer.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 1f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, LookRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, LookRadiusDisparo);
    }
}
