using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntrarAlaTorre : MonoBehaviour
{
    [Header("Configuración de transición")]
    public string sceneToLoad;            // Nombre de la escena a la que quieres ir
    public string spawnPointName;         // Nombre del punto donde el jugador aparecerá en esa escena

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Guardamos el punto de entrada para la próxima escena
            SceneData.spawnPoint = spawnPointName;

            // Cargamos la nueva escena
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}