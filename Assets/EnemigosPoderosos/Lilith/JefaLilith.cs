using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class JefaLilith : MonoBehaviour
{
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
    private Transform PlayerPointer;
    public float Rango;
    public float Melee;

    public Image BarraVida;
    public float VidaActual;
    public float VidaMaxima = 2000;


    public AudioSource AuraAudioSource;
    public AudioClip AuraSonido;
    public AudioSource SourceGeneral;
    public AudioClip Caminar;

    private void Awake()
    {
        VidaActual = 2000;
        VidaLilith = VidaActual;

    }
    void Start()
    {
        Animator = GetComponentInChildren<Animator>();
        agentLilith = GetComponent<NavMeshAgent>();
        AuraAudioSource = GetComponentInChildren<AudioSource>();
        rb = GetComponent<Rigidbody>();

        Player = GameObject.FindWithTag("Player");
        PlayerPointer = Player.transform.Find("PlayerPointer");
       

        Debug.Log("Tienes agallas para desafiarme, simple mortal");
        Fases = 1;
        Daño = 30;
        trigger = GetComponent<SphereCollider>(); 
        trigger.isTrigger = true;
        

        
        
        Aura = false;
        ParticulasDerrota.SetActive(false);
        CirculoFisicoAura.SetActive(false);
        StartCoroutine(ActivarAuraAleatoriamente());







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
        if(VidaLilith <= 1000 && Fases == 1)
        {
            Fase2();
            Fases = 2;

        }
        //if(Fases == 2 && ) //Aqui se pondra la regeneración. Cuando tenga el modelo, animaciones y NavMesh configurado.
    }

    
    void Comportamiento()
    {
        float distancia = Vector3.Distance(PlayerPointer.position, transform.position);
        if (!Derrotada)
        {
            if (distancia <= Rango && Atacando == false && !Derrotada)
            {



                agentLilith.SetDestination(PlayerPointer.position);
                FaceTarget();
                Animator.SetBool("Correr", true);
                Animator.SetBool("Golpe1", false);


                agentLilith.speed = 10f;

                Debug.Log("En Combate");




            }
            if (distancia <= Melee)
            {
                Animator.SetBool("Correr", false);
                Animator.SetBool("Golpe1", true);
                agentLilith.speed = 0f;
                Atacando = true;
                agentLilith.enabled = false;

            }
            else
            {
                Atacando = false;
                agentLilith.enabled = true;

            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Rango);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, Melee);

    }
    void Fase2()
    {
        Debug.Log("FASE 2");
        Daño = 60;
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

}
