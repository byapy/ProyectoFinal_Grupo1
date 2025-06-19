using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //3 Imagenes para las barras
    //5 Textos, 3 pociones, 1 de dinero y uno para mensajes que querramos meter
    [SerializeField]private float VelocidadDeAnimacion = 20f;
    public Image BarraVida, BarraVidaPerdida, BarraDefensa, BarraAtaque;
    public Text TxtPVida, TxtPDefensa, TxtPAtaque, TxtDinero, TxtGemasRecolectadas;

    public Text TxtInvPVida, TxtInvPDefensa, TxtInvPAtaque;


    //Armas compradas
    public Image ImgPistola, ImgEspada;

    //Gemas que se veran en el canva de pausa
    public Image Gema1, Gema2, Gema3;
    //Esta variable va a ser la que vamos a llamar para que esté mostrando
    //mensajes durante el gameplay
    public Text TxtConsola;


    public static UIController Instance;

    private void Awake()
    {
        Instance = this;
        ImgEspada.gameObject.SetActive(StatsPlayer.TieneEspada);
        ImgPistola.gameObject.SetActive(StatsPlayer.TieneMosquete);
    }


    // Start is called before the first frame update
    void Start()
    {
        BarraVida.fillAmount = StatsPlayer.PVidaActual / StatsPlayer.PVidaMaxima;

        BarraVidaPerdida.fillAmount = BarraVida.fillAmount;

        BarraDefensa.fillAmount = 0;
        BarraAtaque.fillAmount = 0;

        TxtDinero.text = StatsPlayer.PDinero.ToString();

        //Pociones en Fila 0 son Vida, 1 son Defensa y 2 son ataque.
        TxtPVida.text = StatsPlayer.PPociones[0].ToString();
        TxtPVida.color = ColorAlTexto(StatsPlayer.PPociones[0]);
        TxtPDefensa.text = StatsPlayer.PPociones[1].ToString();
        TxtPDefensa.color = ColorAlTexto(StatsPlayer.PPociones[1]);
        TxtPAtaque.text = StatsPlayer.PPociones[2].ToString();
        TxtPAtaque.color = ColorAlTexto(StatsPlayer.PPociones[2]);

        //Asignar valores al inventario
        TxtInvPAtaque.text = TxtPAtaque.text;
        TxtInvPAtaque.color = TxtPAtaque.color;

        TxtInvPDefensa.text = TxtPDefensa.text;
        TxtInvPDefensa.color = TxtPDefensa.color;

        TxtInvPVida.text = TxtPVida.text;
        TxtInvPVida.color = TxtPVida.color;


    }

    //20 segundos defensa, 15 ataque
    // Update is called once per frame
    void Update()
    {
        BarraVida.fillAmount = StatsPlayer.PVidaActual / StatsPlayer.PVidaMaxima;
        StartCoroutine(BajarVida());


        BarraDefensa.fillAmount = StatsPlayer.TiempoDefensa / 20;
        BarraAtaque.fillAmount = StatsPlayer.TiempoAtaque / 15;

        TxtDinero.text = StatsPlayer.PDinero.ToString();

        TxtPVida.text = StatsPlayer.PPociones[0].ToString();
        TxtPVida.color = ColorAlTexto(StatsPlayer.PPociones[0]);

        TxtPDefensa.text = StatsPlayer.PPociones[1].ToString();
        TxtPDefensa.color = ColorAlTexto(StatsPlayer.PPociones[1]);

        TxtPAtaque.text = StatsPlayer.PPociones[2].ToString();
        TxtPAtaque.color = ColorAlTexto(StatsPlayer.PPociones[2]);

        //Asignar valores al inventario
        TxtInvPAtaque.text = TxtPAtaque.text;
        TxtInvPAtaque.color = TxtPAtaque.color;
        
        TxtInvPDefensa.text = TxtPDefensa.text;
        TxtInvPDefensa.color = TxtPDefensa.color;

        TxtInvPVida.text = TxtPVida.text;
        TxtInvPVida.color = TxtPVida.color;


        TxtGemasRecolectadas.text = Mecanica_Recoleccion.Gema.ToString();
        ActualizacionImagenesGemas();
    }

    public IEnumerator BajarVida()
    {
        BarraVidaPerdida.fillAmount = Mathf.MoveTowards(BarraVidaPerdida.fillAmount, BarraVida.fillAmount, VelocidadDeAnimacion * Time.deltaTime);
        yield return new WaitForSeconds(2f);

    }
    public void ActivarArmaNueva(string Nombre)
    {
        switch(Nombre.ToLower())
        {
            case "espada":
                    ImgEspada.gameObject.SetActive(true);
                    break; 
            case "mosquete":
                    ImgPistola.gameObject.SetActive(true);
                    break;
        }
    }

    public void UsarPocion(string TipoPocion)
    {
        StatsPlayer.Instance.UsarPocion(TipoPocion);
    }
    public void MensajeAConsola(string Mnsj)
    {
        TxtConsola.text = Mnsj;
    }
    
    Color ColorAlTexto(int numeroPociones)
    {
        switch(numeroPociones)
        {
            case 0:
                return Color.red;    
            case 15:
                return Color.green;
            default:
                return Color.white;
        }
    }

    //Metodo que segun las gemas que recolecte se activan en el panel de pausa
    void ActualizacionImagenesGemas()
    {
        int cantidadGemas = Mecanica_Recoleccion.Gema;
        Gema1.gameObject.SetActive(cantidadGemas >= 1);
        Gema2.gameObject.SetActive(cantidadGemas >= 2);
        Gema3.gameObject.SetActive(cantidadGemas >= 3);

    }
}
