using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlScenes : MonoBehaviour
{
    public GameObject PanelPausa;
    public GameObject PanelGamePlay;
    private MovAnimacionesArmas ataque;

    public static ControlScenes Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Time.timeScale = 1;
        PanelGamePlay.SetActive(true);

        //Para que el player no registre movimientos ni ataques
        MovAnimacionesArmas.IsPaused = false;
    }
    public void CargarEscena()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void CargarEscenaInicio()//Carga la escena principal desde el panel perdiste
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void ReiniciarEscena()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

}
