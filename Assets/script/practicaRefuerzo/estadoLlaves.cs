using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estadoLlaves : MonoBehaviour
{
    public int llaves;
    public GameObject fuego;

    public Animator puertaT;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Consigue las 3 llaves cohete para abrir la puerta en la cima de la torre y ganar el nivel 2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "llave")
        {
            llaves = llaves + 1;
            Destroy(collision.transform.gameObject);
        }
        if (llaves == 3)
        {
            puertaT.SetBool("abrir", true);
            Debug.Log("Bien la puerta se abrio en la cima ya puedes pasar");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Finish")
        {
            Debug.Log("Ganaste el nivel 2");
            fuego.SetActive(true);
        }
    }
}
