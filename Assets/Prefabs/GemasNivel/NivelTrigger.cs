using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NivelTrigger : MonoBehaviour
{
    public int nivelId;
    public PlayerController playerController;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerController != null)
            {
                if (nivelId > playerController.nivelProgreso)
                {
                    playerController.nivelProgreso = nivelId;
                    Debug.Log($"Nivel {nivelId} asignado al jugador");
                }

            }

        }

    }
}
