using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecanica_Recoleccion : MonoBehaviour
{
    public static int Gema;

    private void OnTriggerEnter(Collider other)
    {
        UIController.Instance.MensajeAConsola("Se agarró " + other.tag);

        switch (other.tag.ToLower())
        {
            case "saco10":
                StatsPlayer.Instance.AgregarDinero(10);
                break;
            case "saco50":
                StatsPlayer.Instance.AgregarDinero(50);
                break;
            case "vida":
                StatsPlayer.Instance.AgregarPocion(other.tag.ToLower());
                break;
            case "defensa":
                StatsPlayer.Instance.AgregarPocion(other.tag.ToLower());
                break;
            case "ataque":
                StatsPlayer.Instance.AgregarPocion(other.tag.ToLower());
                break;
            case "gema":
                Gema = Gema + 1;
                if (Gema >= 3)
                {
                    Debug.Log("Has conseguido la gema completa");
                }
                Destroy(other.gameObject);
                break;

                //Agregar booleanas con tags de armas
        }
    }
    //Meter en el código lo de añadir las partes de la gema
            

}