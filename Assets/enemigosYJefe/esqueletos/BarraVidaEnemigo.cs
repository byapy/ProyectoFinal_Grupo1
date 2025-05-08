using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVidaEnemigo : MonoBehaviour
{
    [SerializeField] private Image BarraVida;
    [SerializeField] private Camera camara;

    public void ActualizarBarra(float VidaActual, float ValorMaximo)
    {
        BarraVida.fillAmount = VidaActual/ValorMaximo;
    }

    private void Update()
    {
        transform.rotation = camara.transform.rotation;
    }

}
