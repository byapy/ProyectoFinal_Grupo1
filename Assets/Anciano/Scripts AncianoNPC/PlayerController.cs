using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public static int nivelProgreso = 1;
    public static GameObject CamaraPlayer;
    public GameObject PuertaBloqueo;
    public GameObject Fuego;

    private void Awake()
    {
        CamaraPlayer = GameObject.Find("CameraAprediz");
        Cursor.lockState = CursorLockMode.Confined;
    }

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
        PuertaBloqueo.SetActive(nivelProgreso < 2); //Aqui mientras sea menor a 3, va estar false
        Fuego.SetActive(nivelProgreso >= 3); //Lo mismo pero con true, en las fogatas que aparecen cuando esta abierto.

    }

    public void ActualizarProgreso(int GemaRecolectada)
    {
        nivelProgreso = GemaRecolectada;
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
    }
    
}
