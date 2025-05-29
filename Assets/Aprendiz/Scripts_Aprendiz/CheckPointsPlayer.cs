using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsPlayer : MonoBehaviour
{
    static Transform PuntoControl;
    public static CheckPointsPlayer Instancia;

    private void Awake()
    {
        Instancia = this;

    }

    private void Start()
    {

    }
    //AprendizArmasConfigurado
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Respawn"))
        {
            PuntoControl = other.transform;
            Debug.Log($"El valor es {PuntoControl.position}");
        }
    }

    public void ReiniciarPosicion()
    {
        if (PuntoControl != null) 
        { 
            gameObject.SetActive(false);
            transform.position = PuntoControl.position;
            gameObject.SetActive(true);
        }
    }

}
