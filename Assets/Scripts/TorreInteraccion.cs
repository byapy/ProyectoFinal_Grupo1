using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreInteraccion : MonoBehaviour
{
    public GameObject CamaraJugador;
    public GameObject CamaraCenital;
    public GameObject Particulas;
    private GameObject Player;
    public GameObject Dialogo;
    // Teletransporte:
    public Transform Destino;

    private MovAnimacionesArmas scriptArmas; // Referencia al script de movimiento del jugador

    void Start()
    {
        // CamaraJugador = GameObject.Find("CameraAprediz");
        CamaraCenital.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CamaraCenital.SetActive(true);
            Particulas.SetActive(true);
            Player = other.gameObject;

            // Obtener el componente de movimiento y desactivarlo
            scriptArmas = Player.GetComponent<MovAnimacionesArmas>();
            if (scriptArmas != null)
            {
                scriptArmas.enabled = false;  // Desactivar el movimiento
            }

            CajaDeDialogo();
        }
    }

    public void CajaDeDialogo()
    {
        Dialogo.SetActive(true);
    }

    public void Teleport()
    {
        if (Player != null && Destino != null)
        {
            Player.transform.position = Destino.position;
            Player.transform.rotation = Destino.rotation;

            // Reactivar el movimiento del jugador
            if (scriptArmas != null)
            {
                scriptArmas.enabled = true;  // Reactivar el script de movimiento
            }

            StartCoroutine(FinalizarTeletransporte());
        }
        else
        {
            Debug.LogWarning("Player o Destino no están asignados.");
        }
    }

    private IEnumerator FinalizarTeletransporte()
    {
        yield return null; // Espera 1 frame

        CamaraJugador = Player.transform.Find("CameraAprediz")?.gameObject;

        CamaraCenital.SetActive(false);
        Dialogo.SetActive(false);

        if (CamaraJugador != null)
        {
            CamaraJugador.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No se encontró la cámara 'CameraAprediz' dentro del jugador.");
        }
    }
}
