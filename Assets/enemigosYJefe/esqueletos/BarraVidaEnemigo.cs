using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVidaEnemigo : MonoBehaviour
{
    [SerializeField] private Image BarraVida;

    public void ActualizarBarra(float VidaActual, float ValorMaximo)
    {
        BarraVida.fillAmount = VidaActual/ValorMaximo;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - PlayerController.CamaraPlayer.transform.position);
    }

}
