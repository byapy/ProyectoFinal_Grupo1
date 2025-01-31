using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class MaestraNegra : MonoBehaviour
{
    public NavMeshAgent AgentMaestraN;
    public Transform PlayerPointer;
    public float RadioDeVision;
    public float RadioDisparo;
    public float RadioAtaque;
    public float RadioMelee;

    public Animator Animator;

    public GameObject Mosquete;
    public GameObject Cuerpo;
    private bool rotacion = false;
    private Quaternion rotacionInicial;
    void Start()
    {
       
        Animator = GetComponentInChildren<Animator>();
        rotacionInicial = Cuerpo.transform.rotation;
    }


    void Update()
    {
        Movimiento();
    }
    public void Movimiento()
    {
        float distancia = Vector3.Distance(PlayerPointer.position, transform.position);

        //Este es el rango en el que te va seguir para atacar a melee.
        if (distancia <= RadioAtaque)
        {
            {

                Cuerpo.transform.Rotate(0, 0, 0);
                AgentMaestraN.SetDestination(PlayerPointer.position);
                FaceTarget();

                Debug.Log("Siguiendote");
                Mosquete.SetActive(false);

                Animator.SetBool("Caminando", true);
                Animator.SetBool("Disparando", false);
                AgentMaestraN.speed = 5f;



            }

        }
        else
        {
            Animator.SetBool("Caminando", false);
            AgentMaestraN.speed = 0f;
            

        }
        //Aqui va a empezar a atacar a distancia.
        if (distancia <= RadioDisparo)
        {
            FaceTarget();
            Debug.Log("Disparando");
            Mosquete.SetActive(true);
            Animator.SetBool("Disparando", true);

            if (!rotacion)
            {
                Cuerpo.transform.Rotate(0, 90, 0);
                rotacion = true;
            }


        }
        else
        {
            Mosquete.SetActive(false);
            Animator.SetBool("Disparando", false);
        }

        //Aqui va a detectarte pero no hara nada.
        if (distancia <= RadioDeVision)
            {
                FaceTarget();

            }
        if (distancia <= RadioMelee)
        {
            Animator.SetBool("MeleeSacarArma", true);
        }
       


        void FaceTarget()
        {
            Vector3 direction = (PlayerPointer.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RadioDeVision);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, RadioDisparo);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, RadioAtaque);

        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, RadioMelee);

    }
}

    

