using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAnimationEvents : MonoBehaviour
{

    public GameObject PantallaGameOver, PantallaGameplay;

    //public GameObject PanelNegro;
    //public CanvasGroup textoHasM;
   // public GameObject textoHasM;

    //Variables de hitboxes
    public GameObject HitboxSinArma, HitboxLanza, HitboxEspada;

    //Variables de Audio
    public AudioClip ClipAttack;
    public AudioSource Source;

    public void PlayerDies()
    {
        PantallaGameOver.SetActive(true);
       
        PantallaGameplay.SetActive(false); 
        Time.timeScale = 0;

        //LeanTween.scale( textoHasM, new Vector3(1f, 1f, 1f), 0.5f).setDelay(1f).setEase(LeanTweenType.easeInOutBack);
        //textoHasM.LeanAlpha(1, 1f);//le da opacidad
       // LeanTween.moveLocal(PanelNegro, new Vector3(0f, 0f, 0f), 0.5f).setDelay(1f).setEase(LeanTweenType.easeInOutBack);//este lo mueve para arriba
       
        //Aqui estaba poniendo las animaciones 
        


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

 

}
