using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSystem : MonoBehaviour
{
    public static CheckPointSystem Instancia;

    public static Vector3 PuntoControl;

    public GameObject Player;


   /* private void Awake()
    {
        if(PuntoControl != null) Debug.Log($"Se despertó el script. El valor de inicial puntocontrol es {PuntoControl}");

        PuntoControl = GameObject.Find("SpawnPointInicial").transform.position;
        Instancia = this;
        Debug.Log($"Se despertó el script. El valor nuevo de puntocontrol es {PuntoControl}");

    }

    private void Start()
    {
        LoadCheckPoint();
    }

    public void LoadCheckPoint()
    {
        Debug.Log($"Se ha cargado un punto de control. El player está en {Player.transform.position} y va a {PuntoControl.position}");

        Instantiate(Player, transform. PuntoControl, Quaternion.identity);
    }

   /* public void SetCheckpoint(Transform checkpoint)
    {
        PuntoControl = checkpoint;
        Debug.Log($"Nuevo punto de control. Ahora su valor es {PuntoControl.position}");

    }*/

}
