using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barraVidaJefe : MonoBehaviour
{
    [SerializeField] private Image BarraVida;

    public void ActualizarBarra(float VidaActual, float ValorMaximo)
    {
        BarraVida.fillAmount = VidaActual / ValorMaximo;
    }
    void Update()
    {
        
    }
}
