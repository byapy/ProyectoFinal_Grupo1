using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cargarJefe : MonoBehaviour
{
    public GameObject villano;
    public GameObject camaraEntrada;
    public GameObject particula1;
    public GameObject panelNombreJ;

    public float conteoRegresivo;
    public float entradaJefe;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        camaraEntrada.SetActive(true);
        panelNombreJ.SetActive(true);
        entradaDelJefe();
        cambio();
    }

    public void cambio()
    {
        conteoRegresivo = conteoRegresivo - Time.deltaTime;

        if(conteoRegresivo <= 0)
        {
            camaraEntrada.SetActive(false);
            panelNombreJ.SetActive(false);

            conteoRegresivo = 0;
        }
    }
    public void entradaDelJefe()
    {
        entradaJefe = entradaJefe - Time.deltaTime;
        if(entradaJefe <= 0)
        {
            villano.SetActive(true);
            particula1.SetActive(true);
            entradaJefe = 0; 
        }
    }    

  
}
