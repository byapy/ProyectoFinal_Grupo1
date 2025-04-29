using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertas : MonoBehaviour
{
    public Animator puerta;
    public Animator puerta2;
    public Animator puerta3;
    public Animator puerta4;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "colisionP1")
        {
            puerta.SetBool("Abrir", true);
            puerta.SetBool("Cerrar", false);
           }
        if (other.transform.name == "colisionP2")
        {
            puerta2.SetBool("Abrir1", true);
            puerta2.SetBool("Cerrar1", false);
        }
        if (other.transform.name == "colisionP3")
        {
            puerta3.SetBool("Abrir2", true);
            puerta3.SetBool("Cerrar2", false);
        }
        if (other.transform.name == "colisionP4")
        {
            puerta4.SetBool("Abrir3", true);
            puerta4.SetBool("Cerrar3", false);
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.transform.name == "colisionP1")
        {
            puerta.SetBool("Cerrar", true);
            puerta.SetBool("Abrir", false);
        }
        if (other.transform.name == "colisionP2")
        {
            puerta2.SetBool("Cerrar1", true);
            puerta2.SetBool("Abrir1", false);
        }
        if (other.transform.name == "colisionP3")
        {
            puerta3.SetBool("Cerrar2", true);
            puerta3.SetBool("Abrir2", false);
        }
        if (other.transform.name == "colisionP4")
        {
            puerta4.SetBool("Cerrar3", true);
            puerta4.SetBool("Abrir3", false);
        }
    }
}
