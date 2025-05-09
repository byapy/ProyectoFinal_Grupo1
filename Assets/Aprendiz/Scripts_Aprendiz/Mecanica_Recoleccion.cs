using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecanica_Recoleccion : MonoBehaviour
{
    public int Gema;

    private void OnTriggerEnter(Collider other)
    {
        UIController.Instance.MensajeAConsola("Se agarró " + other.tag);

        switch (other.tag)
        {
            case "Saco10":
                StatsPlayer.Instance.AgregarDinero(10);
                break;
            case "Saco50":
                StatsPlayer.Instance.AgregarDinero(50);
                break;
            case "Vida":
                StatsPlayer.Instance.AgregarPocion(other.tag.ToLower());
                break;
            case "Defensa":
                StatsPlayer.Instance.AgregarPocion(other.tag.ToLower());
                break;
            case "Ataque":
                StatsPlayer.Instance.AgregarPocion(other.tag.ToLower());
                break;
        }
        if (other.transform.tag == "Gema")
        {
            Gema = Gema + 1;
            Destroy(other.transform.gameObject);
            Debug.Log($"Has obtenido la gema {Gema}");
            if (Gema >= 3)
            {
                Debug.Log("Has conseguido la gema completa");
            }
        }

    }
    //Meter en el código lo de añadir las partes de la gema
            

}