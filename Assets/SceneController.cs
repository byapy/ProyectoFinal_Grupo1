using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public GameObject playerPrefab; // Arrastrá el prefab desde tu carpeta de prefabs

    void Start()
    {
        string spawnName = string.IsNullOrEmpty(SceneData.spawnPoint) ? "SpawnInterior" : SceneData.spawnPoint;
        Debug.Log("SpawnPoint usado: " + spawnName);

        GameObject spawnPoint = GameObject.Find(spawnName);
        if (spawnPoint != null)
        {
            Instantiate(playerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
            Debug.Log("Jugador instanciado correctamente.");

        }
        else
        {
            Debug.LogWarning("No se encontró el spawn point con nombre: " + spawnName);
        }
    }
}