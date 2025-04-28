using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecanica_Recoleccion : MonoBehaviour
{
    public int Dinero;
    public int Vida;
    public int Defensa;
    public int Ataque;
    public int Gema;
    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collisionplayer)
    {
        if (collisionplayer.transform.tag == "Saco10")
        {
            if (Dinero < 200)
            {
                Dinero = Dinero + 10;
                Destroy(collisionplayer.transform.gameObject);
                Debug.Log("Has recolectado un saco de 10 monedas");

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
        }

    }
}