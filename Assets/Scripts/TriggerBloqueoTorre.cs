using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerBloqueoTorre : MonoBehaviour
{
    public GameObject CartelPuerta;

    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
                if (PlayerController.Instance.nivelProgreso < 3)
                {
                    CartelPuerta.SetActive(true);
                    Debug.Log("Vuelve cuando tengas todas las gemas");
                }

            
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
                if (PlayerController.Instance.nivelProgreso < 3)
                {
                    CartelPuerta.SetActive(false);
                }

            
        }
    }
    public void CerrarCaja()
    {
        CartelPuerta.SetActive(false);

    }
}
