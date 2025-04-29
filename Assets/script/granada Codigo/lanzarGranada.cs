using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanzarGranada : MonoBehaviour
{
    public GameObject granada;
    public Transform puntoGranada;

    public float velocidadGra;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            llamarGranada();
        }
    }

    void llamarGranada()
    {
        GameObject copiarGranada = Instantiate(granada, puntoGranada.position, puntoGranada.rotation);
        copiarGranada.GetComponent<Rigidbody>().AddForce(puntoGranada.forward * velocidadGra, ForceMode.Impulse);
    }
}
