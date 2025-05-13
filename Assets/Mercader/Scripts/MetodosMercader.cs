using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetodosMercader : MonoBehaviour
{

    public GameObject CanvasCompra;

    private void OnTriggerEnter(Collider other)
    {
        CanvasCompra.SetActive(true);
        ActivarAnimacionesMercader.Instance.SaludarAlJugador();
    }

    private void OnTriggerExit(Collider other)
    {
        CanvasCompra.SetActive(false);
    }

}
