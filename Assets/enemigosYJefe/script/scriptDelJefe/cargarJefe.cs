using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cargarJefe : MonoBehaviour
{   // particulas, el jefe y panel de canva a usar
    public GameObject villano;
    public GameObject camaraEntrada;
    public GameObject particula1;
    public GameObject panelNombreJ;
    public GameObject panelVida;
    // Asignar una puerta y tambien se le activa la animacion cuando se necesite 
    public GameObject puerta;
    public Animator cerrarPuerta;
    // busca un objeto en este caso se le asigna el player y tambien buscar un transform en especifico
    public GameObject Player;
    public GameObject transportar;
    // cronometros
    public float conteoRegresivo;
    public float entradaJefe;
    public float tiempoCambio;
    // clip de musica y audios sfx
    public AudioClip pelea;
    public AudioClip ambiente;
    public AudioSource fuentePrueba;
    
    // obtiene el script del player (MovAnimacionesArmas)
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
        if (other.CompareTag("Player"))  
        {
            cambiarAudio();  //Este metodo detiene la musica de ambiente y la cambia por otra (em este caso para el combate)
        }
        
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

    
    public void cambio()
    {
        codigoJugador = Player.GetComponent<MovAnimacionesArmas>(); 
        codigoJugador.enabled = false;  //desactiva el script de movimiento del player para la escena de entrada del jefe

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
            fuentePrueba.Stop();
            tiempoCambio = tiempoCambio - Time.deltaTime;
            if (tiempoCambio <= 0)
            {
                continuarAudioAnterior();
                panelVida.SetActive(false);
                transportar.SetActive(true);
                tiempoCambio = 0;
                
            }
        }
        
    }
    public void cambiarAudio()  // metodo para cambiar el clip de musica por otro clip 
    {
        if(fuentePrueba != null && pelea != null)
        {
            fuentePrueba.Stop();
            fuentePrueba.clip = pelea;
            fuentePrueba.time = 0;
            fuentePrueba.Play();
        }
      
    }

    public void continuarAudioAnterior() // metodo para cambiar el clip de musica por el clip anterior
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
