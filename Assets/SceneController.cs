using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject panelGameOver;
    public GameObject panelGameplay;

    void Start()
    {
        string spawnName = string.IsNullOrEmpty(SceneData.spawnPoint) ? "SpawnInterior" : SceneData.spawnPoint;
        Debug.Log("SpawnPoint usado: " + spawnName);

        GameObject spawnPoint = GameObject.Find(spawnName);
        if (spawnPoint != null)
        {
            GameObject playerInstance = Instantiate(playerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
            Debug.Log("Jugador instanciado correctamente.");

            // Ahora sí: accedés al script desde el objeto instanciado
            PlayerAnimationEvents playerScript = playerInstance.GetComponentInChildren<PlayerAnimationEvents>();
            if (playerScript != null)
            {
                playerScript.PantallaGameOver = panelGameOver;
                playerScript.PantallaGameplay = panelGameplay;
                Debug.Log("✅ Paneles asignados a " + playerScript.name);

            }
            else
            {
                Debug.LogWarning("No se encontró el script PlayerAnimationEvents en el prefab instanciado.");
                Debug.LogError("❌ PlayerAnimationEvents no encontrado en el prefab instanciado.");

            }
        }
        else
        {
            Debug.LogWarning("No se encontró el spawn point con nombre: " + spawnName);
        }
    }
}
