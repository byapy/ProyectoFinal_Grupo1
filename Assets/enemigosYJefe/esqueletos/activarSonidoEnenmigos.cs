using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarSonidoEnenmigos : MonoBehaviour
{
    public GameObject particulaAtaqueE;
    public GameObject particulaPatada;

    public Transform inicioParticula;
    public Transform inicioParticula2;

    public AudioClip clipAtaqueE;
    public AudioClip clipSonidoEnemigo;
    public AudioClip clipDano;
    public AudioClip clipIdleEnemigo;
    public AudioClip clipEnemigoPatada;
    public AudioClip clipGolpeDeEspada;
    public AudioClip clipDerrota;
    public AudioClip clipCaminar1;
    public AudioClip clipCaminar2;
    public AudioSource fuente2;

    public GameObject patadaColision;
    public GameObject espadaColision;

    public void golpe()
    {
        fuente2.PlayOneShot(clipDano);
    }

    public void seguirAlJugador()
    {
        fuente2.PlayOneShot(clipSonidoEnemigo);
    }

    public void enemigoEnEspera()
    {
        fuente2.PlayOneShot(clipIdleEnemigo);
    }

    public void patadaEnemigo()
    {
       
        patadaColision.SetActive(true);
        Instantiate(particulaPatada, inicioParticula2);
    }
    public void patadaAudio()
    {
        fuente2.PlayOneShot(clipEnemigoPatada);
    }
    public void desactivarColisonPatada()
    {
        patadaColision.SetActive(false);
    }

    public void golpeEspada()
    {
        fuente2.PlayOneShot(clipGolpeDeEspada);
        espadaColision.SetActive(true);
        Instantiate(particulaAtaqueE, inicioParticula);
    }

    public void desactivarColisionEspada()
    {
        espadaColision.SetActive(false);
        //lsjdjdsfdsfds
    }

    public void derrota()
    {
        fuente2.PlayOneShot(clipDerrota);
    }

    public void caminar1()
    {
        fuente2.PlayOneShot(clipCaminar1);
    }

    public void caminar2()
    {
        fuente2.PlayOneShot(clipCaminar2);
    }
}
