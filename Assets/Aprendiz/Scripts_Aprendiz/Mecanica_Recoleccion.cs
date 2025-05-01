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
    }
    /*private void OnCollisionEnter(Collision collisionplayer)
    {
        


        if (collisionplayer.transform.CompareTag("Saco10"))
        {
            StatsPlayer.Instance.AgregarDinero(10);
            Destroy(collisionplayer.transform.gameObject);
            Debug.Log("Has recolectado un saco de 10 monedas");

        }

        if (collisionplayer.transform.tag == "Saco50")
        {
            if (Dinero < 200)
            {
                Dinero = Dinero + 50;
                Destroy(collisionplayer.transform.gameObject);
                Debug.Log("Has recolectado un saco de 50 monedas");

                if (Dinero >= 200)
                {
                    Debug.Log("Tu alforja está llena. No puedes recoger más dinero.");
                }
            }
            else
            {
                Debug.Log("Tu alforja está llena. No puedes recoger más dinero.");
            }
        }

        if (collisionplayer.transform.tag == "Saco100")
        {
            if (Dinero < 200)
            {
                Dinero = Dinero + 100;
                Destroy(collisionplayer.transform.gameObject);
                Debug.Log("Has recolectado un saco de 100 monedas");

                if (Dinero >= 200)
                {
                    Debug.Log("Tu alforja está llena. No puedes recoger más dinero.");
                }
            }
            else
            {
                Debug.Log("Tu alforja está llena. No puedes recoger más dinero.");
            }
        }
        if (collisionplayer .transform.tag == "Defensa")
        {
            Defensa = Defensa + 20;
            Destroy(collisionplayer.transform.gameObject);
            Debug.Log("Has recolectado una pocion de defensa, aumentas tu resistencia");
        }

        if (collisionplayer. transform.tag == "Ataque")
        {
            Ataque = Ataque + 15;
            Destroy(collisionplayer.transform.gameObject);
            Debug.Log("Has recolectado una pocion de ataque, aumentas tu fuerza");
        }


        if (collisionplayer.transform.tag == "Gema")
        {
            Gema = Gema + 1;
            Destroy(collisionplayer.transform.gameObject);
            Debug.Log($"Has obtenido la gema {Gema}");
            if (Gema >= 3)
            {
                Debug.Log("Has conseguido la gema completa");
            }
        }*/

}