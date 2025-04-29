using System.Collections;
using System.Collections.Generic;
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
    public float Golpe;
    public Animator Animator;

    public GameObject Mosquete;
    public GameObject Cuerpo;
    public GameObject bala;
    public Transform PointerBala;

    private bool sacandoArma = false;
    private bool armaSacada = false;
    private bool disparando = false;

    void Start()
    {
        Animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Movimiento();
    }

    public void Movimiento()
    {
        float distancia = Vector3.Distance(PlayerPointer.position, transform.position);

        // Si está en rango de melee, comienza a sacar el arma y esperar para caminar
        if (distancia <= RadioMelee)
        {
            if (!sacandoArma && !armaSacada)
            {
                sacandoArma = true;
                Animator.SetBool("MeleeSacarArma", true);  // Empieza la animación de sacar el arma
                StartCoroutine(SacarArmaYCaminar());
            }

            // Solo se mueve hacia el jugador una vez que el arma haya sido sacada
            if (armaSacada)
            {
                AgentMaestraN.SetDestination(PlayerPointer.position);
                FaceTarget();
            }
        }
        else if (distancia <= RadioAtaque)
        {
            // Comienza a caminar hacia el jugador si está dentro del rango de ataque
            AgentMaestraN.SetDestination(PlayerPointer.position);
            FaceTarget();

            Mosquete.SetActive(false);
            Animator.SetBool("Caminando", true);
            Animator.SetBool("Disparando", false);
            disparando = false;

            AgentMaestraN.speed = 5f; // Velocidad de movimiento
        }
        else if (distancia <= RadioDisparo)
        {
            // Comienza a disparar si está dentro del rango de disparo
            FaceTarget();

            Mosquete.SetActive(true);
            Animator.SetBool("Disparando", true);
            Animator.SetBool("Caminando", false);
            disparando = true;

            AgentMaestraN.speed = 0f; // Se queda quieta al disparar

        }
        else if (distancia <= RadioDeVision)
        {
            // Solo gira hacia el jugador si está en el rango de visión
            FaceTarget();
        }
        else
        {
            // Si no está en ningún rango relevante, no hace nada
            Animator.SetBool("Caminando", false);
            Animator.SetBool("Disparando", false);
            disparando = false;
            AgentMaestraN.speed = 0f;
        }
        if (distancia <= Golpe)
        {
            Animator.SetBool("Pegar", true);
            Animator.SetBool("Caminando", false);
            Animator.SetBool("Disparando", false);


            AgentMaestraN.speed = 0f;

        }
        else
        {
            Animator.SetBool("Pegar", false);

        }


        AjustarCuerpo();
    }

    void FaceTarget()
    {
        // Calcula la dirección hacia el jugador sin afectar la inclinación
        Vector3 direction = (PlayerPointer.position - transform.position).normalized;
        direction.y = 0;  // Mantener solo la rotación en el plano XZ
        if (direction == Vector3.zero) return;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void AjustarCuerpo()
    {
        if (disparando)
        {
            // Aplica la rotación de 90° cuando está disparando
            Cuerpo.transform.localRotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            // Restaura la rotación normal del cuerpo
            Cuerpo.transform.localRotation = Quaternion.identity;
        }
    }

    public void Disparo()
    {
        if (bala != null && PointerBala != null)
        {
            GameObject balaInstanciada = Instantiate(bala, PointerBala.position, PointerBala.rotation);

            // Inicializamos la bala para que apunte hacia el jugador
            BalaMovimiento balaScript = balaInstanciada.GetComponent<BalaMovimiento>();
            if (balaScript != null)
            {
                balaScript.Inicializar(PlayerPointer.position); // Apunta hacia el jugador
            }
        }

    }

    private IEnumerator SacarArmaYCaminar()
    {
        // Espera el tiempo de la animación de sacar el arma
        yield return new WaitForSeconds(2.5f); 

        // Termina la animación de sacar el arma
        Animator.SetBool("MeleeSacarArma", false);

        // Solo comienza a caminar una vez que el arma ha sido sacada
        Animator.SetBool("Caminando", true);
        armaSacada = true;  // El arma ya está sacada
        sacandoArma = false; // Ya no está sacando el arma
    }

    private void OnDrawGizmosSelected()
    {
        // Gizmos para visualizar las áreas de rango
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RadioDeVision);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, RadioDisparo);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, RadioAtaque);

        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, RadioMelee);

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, Golpe);
    }
}
