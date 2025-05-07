using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MaestraNegra : MonoBehaviour
{
    // Referencias a componentes
    public static MaestraNegra Instance;

    public NavMeshAgent AgentMaestraN;
    public Transform PlayerPointer;
    public Animator Animator;
    public AudioClip sonidoDisparo;
    public AudioClip MuerteSonido;
    public AudioClip Caminar;



    public AudioSource AudioFuente;

    public float tiempoEntrePasos = 0.5f;




    // Radios y rangos
    public float RadioDeVision;
    public float RadioDisparo;
    public float RadioAtaque;
    public float RadioMelee; // Ya no lo usare
    public float Golpe;

    // Objetos relacionados con las armas y el disparo
    public GameObject Mosquete;
    public GameObject Espada;
    public GameObject Cuerpo;
    public GameObject bala;
    public Transform PointerBala;
    public GameObject ParticulasDerrota;

    // Estado interno
    private bool sacandoArma = false;
    private bool armaSacada = false;
    private bool disparando = false;
    public bool muerta;
    private bool yaMurio = false;


    //Stats
    public int vida = 500;
    public int DañoG;
    public int DañoD;

    void Start()
    {
        StartCoroutine(SonidoPasos());
        Animator = GetComponentInChildren<Animator>();
    }

    private void Awake()
    {
        Instance = this;

    }
    void Update()
    {
        Debug.Log("VIDA:" + StatsPlayer.PVidaActual);


        // Si no está muerta, realiza el movimiento
        if (!muerta)
        {
            Movimiento();
        }
        if (vida <= 0 && !yaMurio)
        {
            muerta = true;
            Muriendo();
        }
        

    }
    private IEnumerator SonidoPasos()
    {
        while (true)
        {
            if (Animator.GetBool("Caminando") && !AudioFuente.isPlaying && !muerta)
            {
                AudioFuente.PlayOneShot(Caminar);
            }

            yield return new WaitForSeconds(tiempoEntrePasos);
        }
    }
    public void Movimiento()
    {

        if (StatsPlayer.PVidaActual <= 0)
        {
            Animator.SetBool("Pegar", false);
            DetenerMovimiento(); 
            AgentMaestraN.ResetPath(); 
            return;
        }

       
        float distancia = Vector3.Distance(PlayerPointer.position, transform.position);

       
        if (distancia <= RadioMelee)
        {
            ManejarMelee(distancia);
        }
        else if (distancia <= RadioAtaque)
        {
            ManejarAtaque(distancia);
        }
        else if (distancia <= RadioDisparo)
        {
            ManejarDisparo(distancia);
        }
        else if (distancia <= RadioDeVision)
        {
           
            FaceTarget();
        }
        else
        {
          
            DetenerMovimiento();
        }

       
        if (distancia <= Golpe)
        {
            ManejarGolpe();
        }
        else
        {
            AgentMaestraN.isStopped = false;

            Animator.SetBool("Pegar", false);
        }

        AjustarCuerpo();
    }

    void Muriendo()
    {
        yaMurio = true;
        Animator.Play("Dying");
        AgentMaestraN.enabled = false;
        Destroy(gameObject, 6);
        Invoke("ActivarParticulaMuerte", 2.5f);
        AudioFuente.PlayOneShot(MuerteSonido);


    }
    void ActivarParticulaMuerte()
    {
        ParticulasDerrota.SetActive(true);
    }
    
    void ManejarMelee(float distancia)
    {
        if (!sacandoArma && !armaSacada)
        {
            sacandoArma = true;
            Espada.SetActive(true);
            Animator.SetBool("MeleeSacarArma", true);  
            StartCoroutine(SacarArmaYCaminar());
        }

    
        if (armaSacada)
        {
            AgentMaestraN.SetDestination(PlayerPointer.position);
            FaceTarget();
        }
    }

    void ManejarAtaque(float distancia)
    {
        
        AgentMaestraN.SetDestination(PlayerPointer.position);
        FaceTarget();

        Mosquete.SetActive(false);
        Animator.SetBool("Caminando", true);
        Animator.SetBool("Disparando", false);
        disparando = false;

        AgentMaestraN.speed = 5f; 
    }

    void ManejarDisparo(float distancia)
    {
        // Dentro del rango de disparo, el enemigo se detiene y dispara
        FaceTarget();

        Mosquete.SetActive(true);
        Animator.SetBool("Disparando", true);
        Animator.SetBool("Caminando", false);
        Espada.SetActive(false);

        disparando = true;

        AgentMaestraN.speed = 0f; // Se queda quieta al disparar
    }

    void ManejarGolpe()
    {
        
        if (!Animator.GetBool("Pegar"))
        {
            Animator.SetBool("Pegar", true);
            Animator.SetBool("Caminando", false);
            Animator.SetBool("Disparando", false);
            Animator.SetBool("MeleeSacarArma", false);

            Espada.SetActive(true);

            AgentMaestraN.speed = 0f; 
            AgentMaestraN.isStopped = true;
        }
        
    }
    

    void DetenerMovimiento()
    {
        // Si no está en ningún rango relevante, detiene el movimiento
        Animator.SetBool("Caminando", false);
        Animator.SetBool("Disparando", false);
        disparando = false;
        AgentMaestraN.speed = 0f;
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
            AudioFuente.PlayOneShot(sonidoDisparo);
            
            BalaMovimiento balaScript = balaInstanciada.GetComponent<BalaMovimiento>();
            if (balaScript != null)
            {
                balaScript.Inicializar(PlayerPointer.position); 
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
