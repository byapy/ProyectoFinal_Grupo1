using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiarMusica : MonoBehaviour
{
    public AudioClip pelea;
    public AudioClip ambiente;
    public AudioSource fuentePrueba;
    void Start()
    {
        cambiarAudio();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cambiarAudio()
    {
        fuentePrueba.Stop();
        fuentePrueba.clip = pelea;
        fuentePrueba.time = 0;
        fuentePrueba.Play();
    }

    public void continuarAudioAnterior()
    {
        fuentePrueba.Stop();
        fuentePrueba.clip = ambiente;
        fuentePrueba.time = 0;
        fuentePrueba.Play();
    }
}
