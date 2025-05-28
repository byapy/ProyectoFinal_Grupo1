using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    public float velocidad = 100f;  
    public float limiteY = 0f;  

    void Update()
    {
        transform.Translate(Vector3.up * velocidad * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Créditos saltados por el jugador");

            SalirDeCreditos();
        }

        if (transform.position.y >= limiteY)
        {
            Debug.Log("Se acabaron los creditos");

            SalirDeCreditos();
        }
    }

    void SalirDeCreditos()
    {
        Debug.Log("Créditos terminados o salidos manualmente. ");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        SceneManager.LoadScene("InicioEcenaFinal");
        
    }
}
