using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class administrarUI : MonoBehaviour
{
    public Text TextoSalud;
    public Text TextoGemas;
    public Image BarraSalud;

    public float saludInicio;
    public float saludMaxima = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextoSalud.text = "Salud " + estadisticasJugador.salud;
        TextoGemas.text = "Gemas " + estadisticasJugador.gemas;

        saludInicio = estadisticasJugador.salud;
        BarraSalud.fillAmount = saludInicio / saludMaxima;
    }
}
