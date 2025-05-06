using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAnimationEvents : MonoBehaviour
{

    public GameObject PantallaGameOver, PantallaGameplay;

    //Variables de hitboxes
    public GameObject HitboxSinArma, HitboxLanza, HitboxEspada;

    public void PlayerDies()
    {
        PantallaGameOver.SetActive(true);
        PantallaGameplay.SetActive(false);
        Time.timeScale = 0;
    }

    public void ActivarHitboxSinArma()
    {
        HitboxSinArma.SetActive(true);
    }
    public void ActivarHitboxEspada()
    {
        HitboxEspada.SetActive(true);
    }
    public void ActivarHitboxLanza()
    {
        HitboxLanza.SetActive(true);

    }
    //*************** DESACTIVACIÓN *********************
    public void DesactivarHitboxSinArma()
    {
        HitboxSinArma.SetActive(false);

    }
    public void DesactivarHitboxEspada()
    {
        HitboxEspada.SetActive(false);

    }
    public void DesactivarHitboxLanza()
    {
        HitboxLanza.SetActive(false);
    }


}
