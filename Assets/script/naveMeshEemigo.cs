using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class naveMeshEemigo : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform pointPlayer;
    public float radio;
    public float radioAtaque;
    public Animator animacionEnemigo;
    void Start()
    {
        animacionEnemigo = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        NavMeshMovimiento();
    }

    public void NavMeshMovimiento()
    {
        float rango = Vector3.Distance(pointPlayer.position, transform.position);
        
        if (rango <= radio)
        {
            Objetivo();
            Agent.SetDestination(pointPlayer.position);
            animacionEnemigo.SetBool("correr", true);
            Agent.speed = 5f;
            if (rango <= radioAtaque)
            {
                Agent.speed = 0f;
                animacionEnemigo.SetBool("ataque", true);
            }
            else
            {
                Agent.speed = 5f;
                animacionEnemigo.SetBool("ataque", false);
            }
        }
        else
        {
            animacionEnemigo.SetBool("correr", false);
            Agent.speed = 0f;
        }
    }
    void Objetivo()
    {
        Vector3 radio = (pointPlayer.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(radio.x, 0, radio.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 1f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radio);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radioAtaque);
    }
}
