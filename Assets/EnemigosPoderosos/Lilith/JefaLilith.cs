using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class JefaLilith : MonoBehaviour
{
    public static JefaLilith Instance;
    public GameObject Player;
    public NavMeshAgent agentLilith;
    public Animator Animator;
    public Rigidbody rb;
    public float VidaLilith;
    public bool Aura;
    public float Fases;
    public float Daño;
    public bool JugadorEnRango;
    public bool Derrotada;
    public bool Atacando;

    //public GameObject AuraParticulas;
    public SphereCollider trigger;
    public GameObject ParticulasDerrota;
    public GameObject CirculoFisicoAura;
    public GameObject LilithModel;
    public GameObject EspadaHit;
    public Transform PlayerPointer;
    public float Rango;
    public float Melee;

    public Image BarraVida;
    public float VidaActual;
    public float VidaMaxima = 2000;


    public AudioSource AuraAudioSource;
    public AudioClip AuraSonido;
    public AudioSource SourceGeneral;
    public AudioClip Caminar;

    private TiposGolpe golpeSeleccionado;
    public int velocidadLi;
    public bool esVulnerable;
    public bool CuracionON;
    private bool animacionTerminada = true;
    private float tiempoEntreGolpes = 2f;
    private float tiempoUltimoGolpe = 0f;

    private void Awake()
    {
        
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;  
            DontDestroyOnLoad(gameObject); 
        }

        VidaActual = 2000;
        VidaLilith = VidaActual;

    }
    void Start()
    {
        Animator = GetComponentInChildren<Animator>();
        agentLilith = GetComponent<NavMeshAgent>();
        AuraAudioSource = GetComponentInChildren<AudioSource>();
        rb = GetComponent<Rigidbody>();
        agentLilith.enabled = true;
        velocidadLi = 10;


        Player = GameObject.FindWithTag("Player");
        PlayerPointer = Player.transform.Find("Pointer");
       

        Debug.Log("Tienes agallas para desafiarme, simple mortal");
        Fases = 1;
        Daño = 30;
        trigger = GetComponent<SphereCollider>(); 
        trigger.isTrigger = true;
        

        
        
        Aura = false;
        ParticulasDerrota.SetActive(false);
        CirculoFisicoAura.SetActive(false);
        agentLilith.speed = velocidadLi;

        StartCoroutine(ActivarAuraAleatoriamente());



        NavMeshHit hit;

        if (NavMesh.SamplePosition(transform.position, out hit, 2.0f, NavMesh.AllAreas))
        {
            transform.position = hit.position;
            Debug.Log("Lilith colocada correctamente en el NavMesh");
        }
        else
        {
            Debug.LogError("Lilith NO está sobre el NavMesh. No podrá moverse.");
        }


    }
    IEnumerator ActivarAuraAleatoriamente()
    {
        while (!Derrotada)
        {
            yield return new WaitForSeconds(Random.Range(3f, 8f));
            
            if (JugadorEnRango)
            {
                Aura = true;
                Debug.Log("Aura Activada");
                CirculoFisicoAura.SetActive(true);

                AuraAudioSource.PlayOneShot(AuraSonido);

                yield return new WaitForSeconds(5f);
                Aura = false;
                CirculoFisicoAura.SetActive(false);
                AuraAudioSource.Stop();


            }


        }
    }

    
    void Update()
    {
        VidaLilith = VidaActual;

        BarraVida.fillAmount = VidaActual / VidaMaxima;

        /*/if (LilithModel != null)
        {
            transform.position = LilithModel.transform.position;

        }
        /*/
        
        if (VidaLilith <= 0 && !Derrotada)
        {
            Derrotada = true;
            Derrota();
            LilithModel = null;
        }
        if (!Derrotada)
        {
            Comportamiento();

        }

        if (Aura == true && !Derrotada)
        {
            DañoDeArea();
            
        }
        else
        {
            CirculoFisicoAura.SetActive (false);
        }
        if (Input.GetKey(KeyCode.U))
        {
            VidaActual = 0;
            VidaLilith = 0;
        }
        if (Input.GetKey(KeyCode.T))
        {
            VidaActual = 1000;
            VidaLilith = 1000;
        }
        if (VidaLilith <= 1000 && Fases == 1)
        {
            Fase2();
            Fases = 2;
            Debug.Log("Lilith entró a Fase2");

        }
        //if(Fases == 2 && ) //Aqui se pondra la regeneración. Cuando tenga el modelo, animaciones y NavMesh configurado.
    }

    private enum TiposGolpe
    {
        Golpe1,
        Golpe2,
        Golpe3,
    }
    void Comportamiento()
    {
        if (esVulnerable) return;


        float distancia = Vector3.Distance(PlayerPointer.position, transform.position);

        if (!Derrotada)
        {
            if (distancia <= Rango && Atacando == false && !Derrotada)
            {
                if (agentLilith.isOnNavMesh)
                { 
                if (animacionTerminada)
                    {
                        agentLilith.SetDestination(PlayerPointer.position);
                        FaceTarget();
                        Animator.SetBool("Correr", true);
                        Animator.SetBool("Golpe1", false);
                        Animator.SetBool("Golpe2", false);
                        Animator.SetBool("Golpe3", false);


                    }




                    Debug.Log("En Combate");
                }
                else
                {
                    Debug.LogWarning("Lilith aun no esta sobre el Navmesh");
                }
            }
           
            if (distancia <= Melee)
            {
                if (Time.time - tiempoUltimoGolpe >= tiempoEntreGolpes)
                {
                    Animator.SetBool("Correr", false);
                    Atacando = true;
                    agentLilith.isStopped = true;
                    animacionTerminada = false;
                    golpeSeleccionado = (TiposGolpe)Random.Range(0, System.Enum.GetValues(typeof(TiposGolpe)).Length);
                    tiempoUltimoGolpe = Time.time;
                }
                

                switch (golpeSeleccionado)
                {
                    case TiposGolpe.Golpe1:
                        Animator.SetBool("Golpe1", true);
                        break;
                    case TiposGolpe.Golpe2:
                        Animator.SetBool("Golpe2", true);
                        break;
                    case TiposGolpe.Golpe3:
                        Animator.SetBool("Golpe3", true);
                        break;
                    default:
                        break;
                }

            }
            else
            {
                Animator.SetBool("Correr", true);
                Atacando = false;
                agentLilith.isStopped = false;
                agentLilith.enabled = true;
                agentLilith.speed = velocidadLi;

                
                   
            }
        }
    }
    
    void Fase2()
    {
        Debug.Log("FASE 2");
        CuracionON = true;
        velocidadLi = 15;
        Daño = 60;
        StartCoroutine(Fase2Inicio());

    }
    public void TerminarAnimacion()
    {
        animacionTerminada = true;
    }
    private IEnumerator Fase2Inicio()
    {
        Animator.SetBool("Correr", false);
        Animator.SetBool("Golpe1", false);

        Animator.Play("Herida");
        esVulnerable = true;
        agentLilith.isStopped = true;

        yield return new WaitForSeconds(5f);
        
        esVulnerable = false;
        agentLilith.isStopped = false;
        Animator.Play("CaminarL");

    }
    void DañoDeArea()
    {
        
       if(Aura == true)
        {
            CirculoFisicoAura.transform.Rotate(0, 10, 0);
            CirculoFisicoAura.SetActive(true);
          //  AuraParticulas.SetActive(true);
        }
       else
        {
            CirculoFisicoAura.transform.Rotate(0, 0, 0);
           // AuraParticulas.SetActive(false);
            CirculoFisicoAura.SetActive(false);
        }

    }
    void FaceTarget()
    {
        Vector3 direction = (PlayerPointer.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void CurarsePorGolpe()
    {
        if (CuracionON && VidaActual < VidaMaxima)
        {
            VidaActual += 30;
            VidaActual = Mathf.Min(VidaActual, VidaMaxima);
            Debug.Log("Lilith se curó al golpear al jugador");
        }
    }

    void Derrota()
    {
        
        Animator.SetBool("Correr", false);
        Animator.SetBool("Golpe1", false);
        Animator.Play("Muerte");

        Debug.Log("Uhhm..Acabas de cometer un error..");
        Debug.Log("Lilith ha sido derrotada");

        Invoke("ActivarParticulas", 4);
        Destroy(LilithModel, 4);


        agentLilith.enabled = false;
            rb.isKinematic = false; 
            rb.useGravity = true;   
            rb.velocity = Vector3.zero;
        NavMeshObstacle obstacle = gameObject.AddComponent<NavMeshObstacle>();
        obstacle.carving = true; 

    }
    void ActivarParticulas()
    {
        ParticulasDerrota.SetActive(true);
        Destroy(gameObject, 8);
    }
    void OnTriggerStay(Collider other)
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Objeto detectado: " + other.gameObject.name);

        if (other.CompareTag("Player")) 
        {
            JugadorEnRango = true;
            Debug.Log("El Jugador esta en el rango");
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            JugadorEnRango = false;
            Debug.Log("El Jugador salió del rango");

        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Rango);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, Melee);

    }
}
