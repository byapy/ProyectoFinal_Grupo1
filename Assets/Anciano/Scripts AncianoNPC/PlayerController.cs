using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] public static int nivelProgreso = 1;
    public static GameObject CamaraPlayer;
    public GameObject PuertaBloqueo;

    private void Awake()
    {
        CamaraPlayer = GameObject.Find("CameraAprediz");
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Start()
    {
        Instance = this;
        ActualizarPuerta();
    }
    public void AumentarProgreso()
    {
        nivelProgreso++;
        Debug.Log($"Progreso actualizado Nivel actual {nivelProgreso}");
        ActualizarPuerta();
    }
    
    public void ActualizarPuerta()
    {
        if(nivelProgreso >= 3)
        {
            PuertaBloqueo.SetActive(false);
        }
   

    }

    public void ActualizarProgreso(int GemaRecolectada)
    {
        nivelProgreso = GemaRecolectada;
        ActualizarPuerta();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (nivelProgreso < 3)
            {
                //Debug.Log("Regresa cuando tengas todas las gemas");

            }

            if(nivelProgreso >= 3)
            {
                PuertaBloqueo.SetActive(false);
            }
            
        }
    }
    
}
