using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSystem : MonoBehaviour
{
    public static Transform PuntoControl;

    public GameObject Player;
    public static CheckPointSystem Instancia;


    private void Awake()
    {
        if(PuntoControl != null) Debug.Log($"Se despertó el script. El valor de inicial puntocontrol es {PuntoControl.position}");

        PuntoControl = GameObject.Find("SpawnPointInicial").transform;
        Instancia = this;
        Debug.Log($"Se despertó el script. El valor nuevo de puntocontrol es {PuntoControl.position}");

    }

    private void Start()
    {
        LoadCheckPoint();
    }

    public void LoadCheckPoint()
    {
        Debug.Log($"Se ha cargado un punto de control. El player está en {Player.transform.position} y va a {PuntoControl.position}");

        Instantiate(Player, PuntoControl.position, PuntoControl.rotation);
    }

   /* public void SetCheckpoint(Transform checkpoint)
    {
        PuntoControl = checkpoint;
        Debug.Log($"Nuevo punto de control. Ahora su valor es {PuntoControl.position}");

    }*/

}
