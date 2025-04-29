using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambioEscenas : MonoBehaviour
{
    public GameObject panelPausa;
    public GameObject panelInventario;
    // public GameObject panelDerrota;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void menuPausa()
    {
        panelPausa.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Inventario()
    {
        panelInventario.SetActive(true);
       // Time.timeScale = 0f;
    }
    public void cerrarInventario()
    {
        panelInventario.SetActive(false);
       
    }
    public void reanudarPartida()
    {
        panelPausa.SetActive(false);
        Time.timeScale = 1f;
    }
    public void cargarEscena()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
       // panelDerrota.SetActive(false);
    }
    public void cargarMenuInicio()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void cargarEscena2()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
        
    }
}

