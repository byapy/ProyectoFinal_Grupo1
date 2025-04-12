using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreInteraccion : MonoBehaviour
{
    public GameObject CamaraJugador;
    public GameObject CamaraCenital;
    public GameObject Particulas;
    private GameObject Player;
    void Start()
    {
        CamaraCenital.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CamaraCenital.SetActive(true);
            Particulas.SetActive(true);

            CajaDeDialogo();

            Player.SetActive(false);
            Player = other.gameObject;
        }
    }



    public void CajaDeDialogo()
    {
        
        Player = GameObject.FindWithTag("Player");
        GameObject playerObj = GameObject.FindWithTag("Player");
        MovAnimacionesArmas scriptArmas = playerObj.GetComponent<MovAnimacionesArmas>();
        

    }
    public void Teleport()
    {

    }
}
