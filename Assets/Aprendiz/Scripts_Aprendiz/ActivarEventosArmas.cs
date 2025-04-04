using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarEventosArmas : MonoBehaviour
{
    public GameObject particulaAtaque;
    public Transform PointerParticulas;
    public AudioClip ClipAttack;

    public AudioSource Sources;
    public void EfectoAtaque()
    {
        Instantiate(particulaAtaque, PointerParticulas);
        Sources.PlayOneShot(ClipAttack);
    }


}

