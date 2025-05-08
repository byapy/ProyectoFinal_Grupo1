using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciaBala : MonoBehaviour
{
    public GameObject bala;
    public GameObject mira;
    public bool mosqueteActivo;
    //Variables de audio
    public AudioClip ClipBoom;
    public AudioSource Source;

    void Start()
    {

    }
    void Update()
    {
        if (mosqueteActivo && Input.GetMouseButtonDown(0))
        {
            dispara();

        }

    }
    public void dispara()
    {
        Instantiate(bala, mira.transform.position, mira.transform.rotation);
        Source.PlayOneShot(ClipBoom);
    }

    
}

