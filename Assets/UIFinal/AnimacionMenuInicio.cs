using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionMenuInicio : MonoBehaviour
{
    public CanvasGroup titulo;
    public CanvasGroup continuar, nuevapartida, ajustes;
    private void Awake()
    {
        Time.timeScale = 1;
    }
    void Start()
    {
        titulo.LeanAlpha(1, 5f).setEase(LeanTweenType.easeInCirc).setOnComplete(PanelBotones);   
    }

    void PanelBotones()
    {
       
       continuar.LeanAlpha(1, 2f);
       nuevapartida.LeanAlpha(1, 2.8f);
       ajustes.LeanAlpha(1, 3.6f);


    }
}
