using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefaLilith : MonoBehaviour
{
    public bool Aura;
    public GameObject AuraFisica;
    public GameObject Player;

    void Start()
    {
        Debug.Log("Tienes agallas para desafiarme, simple mortal");
        Aura = false;
    }


    void Update()
    {
        DañoDeArea();
    }

    

    void DañoDeArea()
    {

       if(Aura == true)
        {
            AuraFisica.SetActive(true);
        }
       else
        {
            AuraFisica.SetActive(false);
        }

    }
    void OnTriggerStay(Collider other)
    {
        
    }


}
