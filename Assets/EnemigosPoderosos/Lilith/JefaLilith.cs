using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class JefaLilith : MonoBehaviour
{
    public NavMeshAgent agentLilith;
    public Animator Animator;
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
    public Transform PlayerPointer;
    public float Rango;
    public float Melee;

    void Start()
    {
        Debug.Log("Tienes agallas para desafiarme, simple mortal");
        VidaLilith = 2000;
        Fases = 1;
        Daño = 30;
        trigger = GetComponent<SphereCollider>(); 
        trigger.isTrigger = true;
  

        
        
        Aura = false;
        ParticulasDerrota.SetActive(false);
        CirculoFisicoAura.SetActive(false);
        StartCoroutine(ActivarAuraAleatoriamente());







        Animator = GetComponentInChildren<Animator>();
    }
    IEnumerator ActivarAuraAleatoriamente()
    {
        while (!Derrotada)
        {
            yield return new WaitForSeconds(Random.Range(10f, 20f));
            
            if (JugadorEnRango)
            {
                Aura = true;
                Debug.Log("Aura Activada");
                CirculoFisicoAura.SetActive(true);


                yield return new WaitForSeconds(5f);
                Aura = false;
                CirculoFisicoAura.SetActive(false);


            }


        }
    }

    
    void Update()
    {
        
        transform.position = LilithModel.transform.position;

        Comportamiento();

        if (VidaLilith <= 0 && !Derrotada)
        {
            Derrotada = true;
            Derrota();
            LilithModel = null;
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
        if (distancia <= Rango)
        {
            {


                agentLilith.SetDestination(PlayerPointer.position);
                FaceTarget();
                Animator.SetBool("Correr", true);           
                Animator.SetBool("Golpe1", false);


                agentLilith.speed = 30f;

                Debug.Log("En Combate");

            }

        }
        if (distancia <= Melee)
        {
            Animator.SetBool("Correr", false);
            Animator.SetBool("Golpe1", true);
            agentLilith.speed = 0f;

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
           // AuraParticulas.SetActive(true);
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
        Animator.SetBool("Muerte", true);
        Debug.Log("Uhhm..Acabas de cometer un error..");
        Debug.Log("Lilith ha sido derrotada");
        Invoke("ActivarParticulas", 5);
        Destroy(LilithModel, 5);
        
        
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
        Debug.Log("Objeto detectado: " + other.gameObject.name); // Muestra qué está tocando el trigger

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
