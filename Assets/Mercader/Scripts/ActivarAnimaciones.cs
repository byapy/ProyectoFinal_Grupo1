using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarAnimaciones : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Animaciones_Mercader;

    void Start()
    {
        Animaciones_Mercader = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaludarAlJugador()
    {
        Animaciones_Mercader.SetBool("Saluda", true);
    }


    public void TerminarSaludo()
    {
        Animaciones_Mercader.SetBool("Saluda", false);
    }



    /*private void OnDrawGizmosSelected() //Para dibujar unas esferas y calcular el tamaño para las distancias a trabajar
    {
        /*Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(7f, 2f, 9f));
        //Gizmos.DrawWireSphere(transform.position, 10f);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 5f);
    }*/
}
