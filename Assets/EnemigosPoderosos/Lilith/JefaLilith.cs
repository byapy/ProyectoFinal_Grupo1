using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefaLilith : MonoBehaviour
{
    public bool Aura;
    //public GameObject AuraParticulas;
    public SphereCollider trigger;


    void Start()
    {
        Debug.Log("Tienes agallas para desafiarme, simple mortal");
        Aura = false;
        trigger = GetComponent<SphereCollider>(); 
        trigger.isTrigger = true;

    }


    void Update()
    {
        DañoDeArea();
    }

    

    void DañoDeArea()
    {

       if(Aura == true)
        {
           // AuraParticulas.SetActive(true);
        }
       else
        {
            // AuraParticulas.SetActive(false);
        }

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
