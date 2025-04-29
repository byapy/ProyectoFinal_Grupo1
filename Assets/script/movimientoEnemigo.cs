using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movimientoEnemigo : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform pointPlayer;
    public float radio;
    public float radioAtaque;
    public Animator animacionEnemigo;

    //public GameObject objeto;
    public GameObject enemigo1;

    [SerializeField] GameObject[] objetos;

   
    public int saludEnemigo;
    public float cronometro;
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
            
            Agent.speed = 3.5f;
            
            if (rango <= radioAtaque)
            {
                Agent.speed = 0f;

                animacionEnemigo.SetBool("correr", false);
                

                animacionEnemigo.SetBool("ataque", true);
                animacionEnemigo.SetBool("patada", true);

            }
            else
            {
                animacionEnemigo.SetBool("ataque", false);
                animacionEnemigo.SetBool("patada", false);
                animacionEnemigo.SetBool("correr", true);
                animacionEnemigo.SetBool("golpess", false);
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
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "simitarra")
        {
            saludEnemigo = saludEnemigo - 90;
            animacionEnemigo.SetBool("golpess", true);

            cronometro = cronometro - Time.deltaTime;
            if(cronometro == 0)
            {
                animacionEnemigo.SetBool("golpess", false);
                cronometro = 0;
            }
            
        }
        
        if (collision.transform.tag == "mosquete")
        {
            saludEnemigo = saludEnemigo - 47;
            animacionEnemigo.SetBool("golpes", true);
        }
       
        if (collision.transform.tag == "lanza")
        {
            saludEnemigo = saludEnemigo - 60;
            animacionEnemigo.SetBool("golpe1", true);
        }
        
        if (saludEnemigo <= 0)
        {
            Agent.speed = 0f;
            radio = 0f;
            Destroy(gameObject, 5f);
            animacionEnemigo.SetBool("derrota", true);
            Posicion();
        }
    }
    public void Posicion()
    {
        int RangoCosas = Random.Range(0, objetos.Length);
        Instantiate(objetos[RangoCosas], enemigo1.transform.position, enemigo1.transform.rotation);
    }
}
