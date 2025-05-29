using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPuerta : MonoBehaviour
{
    public AudioClip puertaAudio;
    public AudioSource fuenteAudio; 

    public void puerta()
    {
        fuenteAudio.PlayOneShot(puertaAudio);

       
    }
}
