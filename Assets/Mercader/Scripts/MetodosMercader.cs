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

    public void CambiarPosicion(Transform PosicionNueva)
    {
        if(MovAnimacionesArmas.Teletransporting)
        {
            transform.SetPositionAndRotation(PosicionNueva.position, PosicionNueva.rotation);
            GameObject GraficosMercader = GameObject.Find("GraficosMercader");
            GraficosMercader.transform.SetPositionAndRotation(PosicionNueva.position, PosicionNueva.rotation);
        }
    }




}
