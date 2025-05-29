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
    public GameObject transportar;

    public float conteoRegresivo;
    public float entradaJefe;
    public float tiempoCambio;

    public AudioClip pelea;
    public AudioClip ambiente;
    public AudioSource fuentePrueba;
    

    private MovAnimacionesArmas codigoJugador;

    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        cambiarAudio();
    }
    public void OnTriggerStay(Collider other2)
    {
       
        camaraEntrada.SetActive(true);
        panelNombreJ.SetActive(true);
        panelVida.SetActive(true);
        cambio();
        
        entradaDelJefe();
        cambioDeArea();
       
        cerrarPuerta.SetBool("cerrar", true);
    }

    public void OnTriggerExit(Collider other)
    {
        continuarAudioAnterior();
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
        
        if (movimientoJefe.saludJefe <= 0)
        {
           
            tiempoCambio = tiempoCambio - Time.deltaTime;
            if (tiempoCambio <= 0)
            {
                transportar.SetActive(true);
                tiempoCambio = 0;
                
            }
        }
        
    }
    public void cambiarAudio()
    {
        if(fuentePrueba != null && pelea != null)
        {
            fuentePrueba.Stop();
            fuentePrueba.clip = pelea;
            fuentePrueba.time = 0;
            fuentePrueba.Play();
        }
      
    }

    public void continuarAudioAnterior()
    {
       if (fuentePrueba != null && ambiente != null)
        {
            fuentePrueba.Stop();
            fuentePrueba.clip = ambiente;
            fuentePrueba.time = 0;
            fuentePrueba.Play();
        }
       
    }

}
