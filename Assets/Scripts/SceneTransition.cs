using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [Header("Configuración de transición")]
    public string sceneToLoad;            // Nombre exacto de la escena destino
    public string spawnPointName;         // Nombre del punto donde el jugador aparecerá en esa escena
    private SceneLoadManager sceneLoadManager;

    private void Start()
    {
        sceneLoadManager = FindObjectOfType <SceneLoadManager>();//
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneData.spawnPoint = spawnPointName;

            if(sceneLoadManager != null)
            {
                sceneLoadManager.LoadSceneByName(sceneToLoad);//
            }
            else
            {
                Debug.LogError("SceneLoadManager no encontradoen la escena");//
                SceneManager.LoadScene(sceneToLoad);
            }
            Destroy(other.gameObject);
            
        }
    }
}
