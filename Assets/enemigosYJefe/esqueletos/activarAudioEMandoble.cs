using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarAudioEMandoble : MonoBehaviour
{
    public GameObject particula1;

    public Transform iniciarParticula;

    public AudioClip ataqueMandoble;
    public AudioClip enemigoIdleMandoble;
    public AudioClip caminarM1;
    public AudioClip caminarM2;
    public AudioClip derrotaM;
    public AudioClip reciveDano;
    public AudioSource fuente3;

    public GameObject colisionMandoble;

    public void enemigoManIdle()
    {
        fuente3.PlayOneShot(enemigoIdleMandoble);
    }

    public void ataqueConMandoble()
    {
        fuente3.PlayOneShot(ataqueMandoble);
        Instantiate(particula1, iniciarParticula);
    }

    public void caminarMandoble1()
    {
        fuente3.PlayOneShot(caminarM1);
    }
    public void caminarMandoble2()
    {
        fuente3.PlayOneShot(caminarM2);
    }
    public void derrotaMandoble()
    {
        fuente3.PlayOneShot(derrotaM);
    }

    public void danoRecivido()
    {
        fuente3.PlayOneShot(reciveDano);
    }

    public void colisionDelMandoble()
    {
        colisionMandoble.SetActive(true);
    }

    public void desactivarColisionMandoble()
    {
        colisionMandoble.SetActive(false);
    }
    
}
