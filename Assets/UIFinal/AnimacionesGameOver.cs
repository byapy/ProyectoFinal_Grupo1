using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesGameOver : MonoBehaviour
{
    [SerializeField] CanvasGroup PanelCompleto, textoHasM;

    // Start is called before the first frame update
    void Start()
    {
        PanelCompleto.LeanAlpha(1, 2f);

        LeanTween.scale(textoHasM.gameObject, new Vector3(1f, 1f, 1f), 0.5f).setDelay(1f).setEase(LeanTweenType.easeInOutBack);
        
        textoHasM.LeanAlpha(1, 1f).setDelay(1.5f).setOnComplete(DetenerTodo);
        
        //le da opacidad

        // LeanTween.moveLocal(PanelNegro, new Vector3(0f, 0f, 0f), 0.5f).setDelay(1f).setEase(LeanTweenType.easeInOutBack);//este lo mueve para arriba

        //Aqui estaba poniendo las animaciones 
    }
    void DetenerTodo()
    {
        Time.timeScale = 0f;
    }
}
