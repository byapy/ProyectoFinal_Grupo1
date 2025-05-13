using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public int nivelProgreso = 1;

    public GameObject PuertaBloqueo;
    public GameObject Fuego;

    public void Start()
    {
        Instance = this;
        ActualizarPuerta();
        Fuego.SetActive(false);
    }
    public void AumentarProgreso()
    {
        nivelProgreso++;
        Debug.Log($"Progreso actualizado Nivel actual {nivelProgreso}");
        ActualizarPuerta();
    }
    
    public void ActualizarPuerta()
    {
<<<<<<< Updated upstream
        PuertaBloqueo.SetActive(nivelProgreso < 3); //Aqui mientras sea menor a 3, va estar false
        Fuego.SetActive(nivelProgreso >= 3); //Lo mismo pero con true, en las fogatas que aparecen cuando esta abierto.
=======
        PuertaBloqueo.SetActive(nivelProgreso < 2); //Aqui mientras sea menor a 3, va estar false
        Fuego.SetActive(nivelProgreso >= 2); //Lo mismo pero con true, en las fogatas que aparecen cuando esta abierto.
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (nivelProgreso < 3)
            {
                Debug.Log("Regresa cuando tengas todas las gemas");

            }

            if(nivelProgreso >= 3)
            {
                PuertaBloqueo.SetActive(false);
            }
            
        }
>>>>>>> Stashed changes
    }
    
}
