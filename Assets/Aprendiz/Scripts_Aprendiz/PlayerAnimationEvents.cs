using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAnimationEvents : MonoBehaviour
{

    public GameObject PantallaGameOver, PantallaGameplay;

    //Variables de hitboxes
    public GameObject HitboxSinArma, HitboxLanza, HitboxEspada;

    //Variables de Audio
    public AudioClip ClipAttack;
    public AudioClip ClipCaminar;
    public AudioClip ClipCorrer;
    public AudioClip ClipIdle;
    public AudioClip Clipland;
    public AudioClip ClipMuerte;

    public AudioSource Source;



    public void PlayerDies()
    {
        PantallaGameOver.SetActive(true);
        PantallaGameplay.SetActive(false);
        Time.timeScale = 0;
    }

    public void ActivarHitboxSinArma()
    {
        HitboxSinArma.SetActive(true);
        Source.PlayOneShot(ClipAttack);
    }
    public void ActivarHitboxEspada()
    {
        HitboxEspada.SetActive(true);
        Source.PlayOneShot(ClipAttack);

    }
    public void ActivarHitboxLanza()
    {
        HitboxLanza.SetActive(true);
        Source.PlayOneShot(ClipAttack);

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

    public void Caminar()
    {
        Source.PlayOneShot(ClipCaminar);
    }
    public void Correr()
    {
        Source.PlayOneShot(ClipCorrer);
    }
    public void Idle()
    {
        Source.PlayOneShot(ClipIdle);
    }
    public void Salto()
    {
        Source.PlayOneShot(Clipland);
    }
    public void Muerte()
    {
        Source.PlayOneShot(ClipMuerte);
    }
}
