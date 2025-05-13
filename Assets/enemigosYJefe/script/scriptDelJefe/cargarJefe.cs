using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cargarJefe : MonoBehaviour
{
    public GameObject villano;
    public GameObject camaraEntrada;
    public GameObject particula1;
    public GameObject panelNombreJ;
    public GameObject panelVida;

    public GameObject puerta;
    public Animator cerrarPuerta;

    public GameObject Player;
    public Transform transportar;

    public float conteoRegresivo;
    public float entradaJefe;
    public float tiempoCambio;

    public bool adentro;

    private MovAnimacionesArmas codigoJugador;

    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other2)
    {
       
            camaraEntrada.SetActive(true);
            panelNombreJ.SetActive(true);
            panelVida.SetActive(true);
            adentro = true;
            cambio();
           // trasladar();
            entradaDelJefe();
            cambioDeArea();
            cerrarPuerta.SetBool("cerrar", true);
        
        
    }
   
    public void cambio()
    {
        codigoJugador = Player.GetComponent<MovAnimacionesArmas>();
        codigoJugador.enabled = false;

        conteoRegresivo = conteoRegresivo - Time.deltaTime;

        if(conteoRegresivo <= 0)
        {
            camaraEntrada.SetActive(false);
            panelNombreJ.SetActive(false);

            codigoJugador.enabled = true;

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

    public void cambioDeArea()
    {
        
        if (movimientoJefe.saludJefe <= 0 && adentro == true)
        {
           
            tiempoCambio = tiempoCambio - Time.deltaTime;
            if (tiempoCambio <= 0)
            {
                trasladar();
                tiempoCambio = 0;
                adentro = false;
            }
        }
        
    }
      public void trasladar()
      {
        Player.transform.position = transportar.position;
        Player.transform.rotation = transportar.rotation;
    }
}
