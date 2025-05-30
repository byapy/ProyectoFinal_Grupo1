using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlScenes : MonoBehaviour
{
    public GameObject PanelPausa;
    public GameObject PanelGamePlay;

    public GameObject PanelGameOver;

    public static ControlScenes Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void MenuPausa()
    {
        PanelPausa.SetActive(true);
        Time.timeScale = 0;
        PanelGamePlay.SetActive(false);

        //Para que el player no registre movimientos ni ataques
        MovAnimacionesArmas.IsPaused = true;
        //Input.ResetInputAxes();
        //animator.ResetTrigger("AttackT");
    }
    public void Continuar()
    {
        PanelPausa.SetActive(false);
        PanelGamePlay.SetActive(true);
        Time.timeScale = 1;

        //Para que el player no registre movimientos ni ataques
        MovAnimacionesArmas.IsPaused = false;
    }

    //Este metodo es para reiniciar en el nivel 1
   public void ReiniciarTodo()
    {
        MovAnimacionesArmas.IsPaused = false;
        SceneManager.LoadScene(1);

        Time.timeScale = 1;
    }

    //Carga a la pantalla de título
    public void CargarEscenaInicio()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    //usado por el botón Reiniciar
    public void ReiniciarEscena()
    {
        PanelPausa.SetActive(false);
        PanelGamePlay.SetActive(true);

        PanelGameOver.SetActive(false);
        Time.timeScale = 1;

        MovAnimacionesArmas.IsPaused = false;
        //SceneManager.LoadScene(1);
    }

}
