using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class eventosJugador : MonoBehaviour
{
    [SerializeField] private UnityEvent ingresaJugador;
    [SerializeField] private UnityEvent salidaJugador;

    private void OnTriggerEnter(Collider objeto)
    {
        if(objeto.transform.tag == "Player")
        {
            ingresaJugador.Invoke();
        }
    }

    private void OnTriggerExit(Collider objeto2)
    {
        if (objeto2.transform.tag == "Player")
        {
            salidaJugador.Invoke();
        }
    }
}
