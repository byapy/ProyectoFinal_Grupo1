using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreInteraccion : MonoBehaviour
{
    public GameObject CamaraJugador;
    public GameObject CamaraCenital;

    void Start()
    {
        CamaraCenital.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CamaraCenital.SetActive(false);
            CamaraCenital.SetActive(true);
            CajaDeDialogo();
            
        }
    }
    public void CajaDeDialogo()
    {
        Debug.Log("¿Ascender?");
        GameObject playerObj = GameObject.FindWithTag("Player");
        MovAnimacionesArmas scriptArmas = playerObj.GetComponent<MovAnimacionesArmas>();
        

    }
}
