using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarEventoAnimacion : MonoBehaviour
{
    public GameObject particulaAtaque;
    public Transform puntoParticula;
    public AudioClip clipAtaque;
    public AudioClip clipCaminar;
    public AudioSource fuente;

    public AudioClip clipAtaqueEnemi;

    public void activarParticula()
    {
        Instantiate(particulaAtaque, puntoParticula);
        fuente.PlayOneShot(clipAtaque);
    }

    public void caminar()
    {
        fuente.PlayOneShot(clipCaminar);
    }

    public void ataqueEnemigo()
    {
        fuente.PlayOneShot(clipAtaqueEnemi);
    }
}
