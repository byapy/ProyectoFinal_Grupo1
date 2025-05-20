using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MetodosMercader : MonoBehaviour
{
    private GameObject CamaraPlayer;

    private void Awake()
    {
        CamaraPlayer = GameObject.Find("CameraAprediz");
    }

    public void ApagarCamaraPlayer()
    {
        CamaraPlayer.SetActive(false);
    }

    public void EncenderCamaraPlayer()
    {
        CamaraPlayer.SetActive(true);
    }

    public void SaludarJugador()
    {
        ActivarAnimacionesMercader.Instance.SaludarAlJugador();
    }
    /* public GameObject CanvasCompra, CanvasInventario, CamaraPlayer, CamaraNPC;
     private void OnTriggerEnter(Collider other)
     {
         CanvasCompra.SetActive(true);
         ActivarAnimacionesMercader.Instance.SaludarAlJugador();
     }

     private void OnTriggerExit(Collider other)
     {
         CanvasCompra.SetActive(false);
         CanvasInventario.SetActive(false);
         CamaraNPC.SetActive(false);
         CamaraPlayer.SetActive(true);
     }*/

}
