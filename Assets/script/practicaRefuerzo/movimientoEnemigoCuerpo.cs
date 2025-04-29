using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movimientoEnemigoCuerpo : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform pointPlayer;
    public float radio;
    public float radioGolpe;
    public Animator animacionEnemigo2;

    public GameObject esfera;

    public int saludEnemigo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    NavMeshMovimiento();
    }
    void Alcanzar2()
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
            Alcanzar2();
            Agent.SetDestination(pointPlayer.position);
            animacionEnemigo2.SetBool("correr1", true);
            Agent.speed = 5f;

            if (rango <= radioGolpe)
            {
                Agent.speed = 0f;
                animacionEnemigo2.SetBool("patada", true);
                esfera.SetActive(true);
            }
            else
            {
                animacionEnemigo2.SetBool("correr1", true);
                animacionEnemigo2.SetBool("patada", false);
                esfera.SetActive(false);
            }
        }
        else
        {
            animacionEnemigo2.SetBool("correr1", false);
            Agent.speed = 0f;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radio);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radioGolpe);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "simitarra")
        {
            saludEnemigo = saludEnemigo - 15;

        }
        if (collision.transform.tag == "mosquete")
        {
            saludEnemigo = saludEnemigo - 10;
            Destroy(collision.transform.gameObject);
        }
        if (collision.transform.tag == "bombas")
        {
            saludEnemigo = saludEnemigo - 100;
            Destroy(collision.transform.gameObject);
        }
        if (saludEnemigo <= 0)
        {
            Agent.speed = 0f;
            radio = 0f;
            Destroy(gameObject, 5f);
            animacionEnemigo2.SetBool("derrota1", true);
            
        }
    }
}
