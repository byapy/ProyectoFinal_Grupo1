using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NivelTrigger : MonoBehaviour
{
    public int nivelId;
    [SerializeField] GameObject GemaGraficos;
    public PlayerController playerController;

    private void Awake()
    {
        if (!Mecanica_Recoleccion.NivelSuperado[nivelId - 1])
        {
            GemaGraficos.SetActive(true);
        }
        else Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerController != null)
            {
                if (nivelId > PlayerController.nivelProgreso)
                {
                    playerController.AumentarProgreso();
                    PlayerController.nivelProgreso = nivelId;
                    Debug.Log($"Nivel {nivelId} asignado al jugador");
                }
            }
        }
    }
    public int NivelSuperado()
    {
        return nivelId - 1;
    }
}
