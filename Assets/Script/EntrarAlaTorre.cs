using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntrarAlaTorre : MonoBehaviour
{
    public static EntrarAlaTorre instance;
    public float CambioNivel;
    public bool ControladorPrincipal = false;

    public void Awake()
    {
        if (ControladorPrincipal)
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                CambioNivel = 1;

            }
            else
            {
                Destroy(gameObject);
            }
        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && instance != null)
        {
            if (!ControladorPrincipal && instance == null)
            {
                Debug.LogWarning("No hay instancia del controlador principal.");
                return;
            }



            if (instance.CambioNivel == 1)
            {
                SceneManager.LoadScene("Torre-Nivel4");
                CambioNivel = 4;
            }
            else if (instance.CambioNivel == 4)
            {
                if (other.CompareTag("Player") && CambioNivel == 4)
                {

                    SceneManager.LoadScene("JuegoFinal");
                    CambioNivel = 1;
                }
            }
        }

        
    }
}
