using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefaLilith : MonoBehaviour
{
    public float VidaLilith;
    public bool Aura;
    public float Fases;
    public float Daño;

    public bool Derrotada;

    //public GameObject AuraParticulas;
    public SphereCollider trigger;
    public GameObject ParticulasDerrota;
    public GameObject CirculoFisicoAura;
    public GameObject LilithModel;
    

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


    }


    void Update()
    {
        if (VidaLilith <= 0 && !Derrotada)
        {
            Derrota();
            LilithModel = null;
        }
        if (Aura == true)
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

    void Derrota()
    {
        Debug.Log("Uhhm..Acabas de cometer un error..");
        Debug.Log("Lilith ha sido derrotada");
        Derrotada = true;
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

        if (other.CompareTag("Player")) // Verifica que sea el jugador
        {

            Debug.Log("El Jugador esta siendo dañado");
            
        }
    }

}
