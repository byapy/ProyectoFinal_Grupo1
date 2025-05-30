using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            CheckPointSystem.Instancia.SetCheckpoint(transform, StatsPlayer.PVidaActual);
            Debug.Log($"Nuevo punto de control {transform.position}, vida {StatsPlayer.PVidaActual}");
        }
    }

}
