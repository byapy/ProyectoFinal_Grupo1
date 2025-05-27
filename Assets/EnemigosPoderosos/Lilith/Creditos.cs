using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    public float velocidad = 30f;  // Velocidad de movimiento hacia arriba
    public float limiteY = 1200f;  // Valor Y para considerar que los créditos terminaron (ajusta según tu UI)

    void Update()
    {
        // Mueve el objeto hacia arriba
        transform.Translate(Vector3.up * velocidad * Time.deltaTime);

        // Salir con ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Créditos saltados por el jugador");

            SalirDeCreditos();
        }

        // Si ya pasó el límite superior de la pantalla
        if (transform.position.y >= limiteY)
        {
            Debug.Log("Se acabaron los creditos");

            SalirDeCreditos();
        }
    }

    void SalirDeCreditos()
    {
        Debug.Log("Créditos terminados o salidos manualmente. Cargando menú...");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        SceneManager.LoadScene("InicioEcenaFinal");
        
    }
}
