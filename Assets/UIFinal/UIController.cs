using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //3 Imagenes para las barras
    //5 Textos, 3 pociones, 1 de dinero y uno para mensajes que querramos meter
    public Image BarraVida, BarraDefensa, BarraAtaque;
    public Text TxtPVida, TxtPDefensa, TxtPAtaque, TxtDinero;
    //Esta variable va a ser la que vamos a llamar para que esté mostrando
    //mensajes durante el gameplay
    public Text TxtConsola;
    
    public static UIController Instance;

    private void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        BarraVida.fillAmount = StatsPlayer.PVidaActual / StatsPlayer.PVidaMaxima;
        BarraDefensa.fillAmount = 0;
        BarraAtaque.fillAmount = 0;

        TxtDinero.text = StatsPlayer.PDinero.ToString();

        //Pociones en Fila 0 son Vida, 1 son Defensa y 2 son ataque.
        TxtPVida.text = StatsPlayer.PPociones[0].ToString();
        TxtPDefensa.text = StatsPlayer.PPociones[1].ToString();
        TxtPAtaque.text = StatsPlayer.PPociones[2].ToString();
    }

    //20 segundos defensa, 15 ataque
    // Update is called once per frame
    void Update()
    {
        BarraVida.fillAmount = StatsPlayer.PVidaActual / StatsPlayer.PVidaMaxima;
        BarraDefensa.fillAmount = StatsPlayer.TiempoDefensa / 20;
        BarraAtaque.fillAmount = StatsPlayer.TiempoAtaque / 15;

        TxtDinero.text = StatsPlayer.PDinero.ToString();
        TxtPVida.text = StatsPlayer.PPociones[0].ToString();
        TxtPDefensa.text = StatsPlayer.PPociones[1].ToString();
        TxtPAtaque.text = StatsPlayer.PPociones[2].ToString();
    }

    public void MensajeAConsola(string Mnsj)
    {
        TxtConsola.text = Mnsj;
    }
    
}
