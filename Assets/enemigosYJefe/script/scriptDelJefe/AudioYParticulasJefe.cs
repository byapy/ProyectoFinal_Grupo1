using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioYParticulasJefe : MonoBehaviour
{
    public GameObject particulaJefe;
    public AudioClip clipAtaqueJefe1;
    public AudioClip clipVozJefe;
    public AudioClip clipAtaqueJefe2;
    public AudioClip clipCaminarJefe1;
    public AudioClip clipCaminarJefe2;
    public AudioClip clipMandobleJefe;
    public AudioClip clipDerrotaJefe;
    public AudioClip clipGolpeJefe;
    public AudioClip clipBurla;
    public AudioClip clipEscudo;
    public AudioClip clipEntrada;
    public AudioClip clipInicioAtaque;

    public Transform puntoParticula1;

    public AudioSource fuente4;

    public void vozJefe()
    {
       fuente4.PlayOneShot(clipVozJefe);
    }
    public void audioAtaqueDelJefe()
    {
        Instantiate(particulaJefe, puntoParticula1);
        fuente4.PlayOneShot(clipAtaqueJefe1);
    }

    public void audioAtaqueJefe2()
    {
        Instantiate(particulaJefe, puntoParticula1);
        fuente4.PlayOneShot(clipAtaqueJefe2);
    }

    public void caminarDelJefe()
    {
        fuente4.PlayOneShot(clipCaminarJefe1);
    }
    public void caminarDelJefe2()
    {
        fuente4.PlayOneShot(clipCaminarJefe2);
    }

    public void mandobleDelJefe()
    {
        fuente4.PlayOneShot(clipMandobleJefe);
    }    

    public void reciveDanoJefe()
    {
        fuente4.PlayOneShot(clipGolpeJefe);
    }

    public void burlaJefe()
    {
        fuente4.PlayOneShot(clipBurla);
    }

    public void audioEscudo()
    {
        fuente4.PlayOneShot(clipEscudo);
    }

    public void audioDerrotaJefe()
    {
        fuente4.PlayOneShot(clipDerrotaJefe);
    }

    public void entradaJefe()
    {
        fuente4.PlayOneShot(clipEntrada);
    }

    public void ataqueInicio()
    {
        fuente4.PlayOneShot(clipInicioAtaque);
    }
}
