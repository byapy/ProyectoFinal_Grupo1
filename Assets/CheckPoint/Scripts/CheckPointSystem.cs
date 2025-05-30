using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSystem : MonoBehaviour
{
    public static CheckPointSystem Instancia;
    public GameObject Player;
    public static Transform PuntoControl;
    float VidaGuardada;

    private void Awake()
    {
        Instancia = this;
    }


    public void LoadCheckPoint()
    {
        if(PuntoControl != null)
        {
           // Debug.Log($"Se ha cargado un punto de control. El player está en {Player.transform.position} y va a {PuntoControl.position}");
            //GameObject todoPlayer = GameObject.Find("AprendizArmasConfigurado");

            Player.SetActive(false);
            StatsPlayer.Instance.SetVida(VidaGuardada);
            Player.transform.SetPositionAndRotation(PuntoControl.position, PuntoControl.rotation);

            //Debug.Log($"Se movió el player a {Player.transform.position}");

            Player.SetActive(true);
            
        }
        else
        {
            //Debug.Log("Se va a cargar el punto de inicio 0");

            Player.SetActive(false);
            Player.transform.SetPositionAndRotation(GameObject.Find("SpawnPointInicial").transform.position, GameObject.Find("SpawnPointInicial").transform.rotation);
            Player.SetActive(true);

            //Debug.Log($"Se movió el player a {Player.transform.position}");

        }

    }

   public void SetCheckpoint(Transform checkpoint, float VidaActual)
    {
        PuntoControl = checkpoint;
        VidaGuardada = VidaActual;
        //Debug.Log($"Nuevo punto de control. Ahora su valor es {PuntoControl.position}");
    }

}
