using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsPlayer : MonoBehaviour
{
    //Para poder acceder a los valores del jugador desde otros scripts
    public static StatsPlayer Instance;


    //variables de solo los objetos que el jugador va a tener
    public static float PVidaActual, PVidaMaxima = 100f;
    public static float PDefensa, PAtaque, PAtaqueBase;
    public static float TiempoDefensa, TiempoAtaque;
    public static int PDinero;

    public static bool BoostDefensa, BoostAtaque;

    public static bool TieneEspada, TieneMosquete;

    public static bool IsAlive;

    //Las pociones y los trozos de Gema van a ser un array de 3 filas
    //Pociones en Fila 0 son Vida, 1 son Defensa y 2 son ataque.
    //Gema en fila 0 va a ser la del tutorial, 1 la del nivel 2 y 2 la del final del nivel 3
    //Todo está inicializado en 0 y False
    public static int[] PPociones = new int[3];
    [SerializeField] GameObject [] ParticulasPociones = new GameObject [3];
    [Space][Header("Scriptable de las Pociones")]
    [SerializeField] ItemUI [] SOPociones;


    private void Awake()
    {
   
        Instance = this;
    }

    void Start()
    {
        PVidaActual = PVidaMaxima;
        IsAlive = true;

    }

    void Update()
    {
        CheckLife();
        DuracionAtaqueExtra();
        DuracionDefensaExtra();
    }

    public void CheckLife()
    {
        if(PVidaActual <= 0)
        {
            IsAlive = false;
        }
    }
    public float CalcularAtaque()
    {
        float AtaqueTotal;
        AtaqueTotal = PAtaqueBase + PAtaque;

        return AtaqueTotal;
    }

    public void ReceivedDamage(float Damage)
    {
        if((Damage - PDefensa) > 0) PVidaActual -= (Damage - PDefensa);
    }

    //Métodos para contar que se acabe el efecto de las pociones de ataque y defensa

    private void DuracionAtaqueExtra()
    {
        if(BoostAtaque)
        { 
            TiempoAtaque -= (1 * Time.deltaTime);

            if(TiempoAtaque <= 0)
            {
                BoostAtaque = false;
                PAtaque = 0;
            }
        }
    }

    private void DuracionDefensaExtra()
    {
        if (BoostDefensa)
        {
            TiempoDefensa -= (1 * Time.deltaTime);

            if (TiempoDefensa <= 0)
            {
                BoostDefensa = false;
                PDefensa = 0;
            }
        }

    }

    //Método para establecer el daño que va a hacer el player
    public void SetPlayerDamage(float Damage)
    {
        PAtaqueBase = Damage;
        //UIController.Instance.MensajeAConsola("El jugador hace un daño base de " + PAtaqueBase);
    }

    //Métodos para contar, agregar y quitar los objetos
    public void UsarPocion(string TipoPocion)
    {
        //Debug.Log(PPociones[0] + " " + PPociones[1] + " " + PPociones[2]);
        if (IsAlive) { 
            switch (TipoPocion)
            {
                case "vida":
                    if (PPociones[0] > 0)
                    {
                        PPociones[0] -= 1;

                        ParticulasPociones[0].SetActive(true);


                        if ((PVidaActual + SOPociones[0].value) >= PVidaMaxima) PVidaActual = PVidaMaxima;
                        else PVidaActual += SOPociones[0].value;
                    }
                    break;

                case "defensa":
                    if (PPociones[1] > 0)
                    {
                        ParticulasPociones[1].SetActive(true);
                        PPociones[1] -= 1;
                        PDefensa = SOPociones[1].value;
                        TiempoDefensa = SOPociones[1].TDuracion;
                        BoostDefensa = true;
                        UIController.Instance.EstablecerLimiteDefensa(TiempoDefensa);

                    }
                    break;

                case "ataque":
                    if (PPociones[2] > 0)
                    {
                        ParticulasPociones[2].SetActive(true);
                        PPociones[2] -= 1;
                        PAtaque = SOPociones[2].value;
                        BoostAtaque = true;
                        TiempoAtaque = SOPociones[2].TDuracion;
                        UIController.Instance.EstablecerLimiteAtaque(TiempoAtaque);
                    }
                    break;
            }
        }
    }

    public void SetVida(float VidaGuardada)
    {
        PVidaActual = VidaGuardada;
    }

    #region Objetos
    public void ActivarArmaNueva(string TipoArma)
    {
        switch (TipoArma.ToLower())
        {
            case "espada":
                TieneEspada = true;
                break;
            case "mosquete":
                TieneMosquete = true;
                break;
        }
    }

    public void AgregarPocion(string TipoPocion)
    {
        switch (TipoPocion)
        {
            case "vida":
                if(PPociones[0] + 1 <= 15) PPociones[0] += 1;
                break;

            case "defensa":
                if (PPociones[1] +1 <= 15) PPociones[1] += 1;
                break;

            case "ataque":
                if (PPociones[2] + 1 <= 15) PPociones[2] += 1;
                break;
        }
    }

    //El dinero tiene un límite de 1000
    public void AgregarDinero(int ValorMoneda)
    {
        if (PDinero + ValorMoneda >= 5000) PDinero = 5000;
        else PDinero += ValorMoneda;
    }
    public void QuitarDinero(int PrecioPagado)
    {
            PDinero -= PrecioPagado;
    }

    public bool PuedeComprar(int PrecioAPagar)
    {
        if (PDinero - PrecioAPagar < 0) return false;
        else return true;
    }

    #endregion

}
