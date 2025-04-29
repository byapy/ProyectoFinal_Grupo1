using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movimientoEnemigoRifle : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform pointPlayer;
    public float radio;
    public float radioDisparo;
    public Animator animacionEnemigo;

    public GameObject bala;
    public Transform posicionBala;

    public float tiempo;
    public float tiempoInicia;

    public int saludSoldado;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     NavMeshMovimiento();
        
    }
    void Alcanzar()
    {
        Vector3 radio = (pointPlayer.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(radio.x, 0, radio.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 1f);
    }
    public void NavMeshMovimiento()
    {
        float rango = Vector3.Distance(pointPlayer.position, transform.position);

        if (rango <= radio)
        {           
            Alcanzar();
            Agent.SetDestination(pointPlayer.position);
            animacionEnemigo.SetBool("correr", true);
            Agent.speed = 5f;

            if (rango <= radioDisparo)
            {
                Agent.speed = 0f;
                animacionEnemigo.SetBool("disparo", true);
                llamarBala();
            }
            else
            {
                animacionEnemigo.SetBool("disparo", false);
            }
        }
        else
        {
            animacionEnemigo.SetBool("correr", false);
            Agent.speed = 0f;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radio);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radioDisparo);
    }

    public void llamarBala()
    {
        tiempoInicia = tiempoInicia - Time.deltaTime;
        if (tiempoInicia <= 0)
        {
         Instantiate(bala, posicionBala.position, posicionBala.rotation);
         tiempoInicia = tiempo;
            //tiempoReiniciar();
        }
    }
    public void tiempoReiniciar()
    {
        tiempoInicia = tiempo;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "mosquete")
        {
            saludSoldado = saludSoldado - 15;
            Destroy(collision.transform.gameObject);
        }
        if (collision.transform.tag == "bombas")
        {
            saludSoldado = saludSoldado - 100;
            Destroy(collision.transform.gameObject);
        }
        if (saludSoldado <= 0)
        {
            Agent.speed = 0f;
            radio = 0f;
            Destroy(gameObject, 5f);
            animacionEnemigo.SetBool("derrota2", true);

        }
    }
}

