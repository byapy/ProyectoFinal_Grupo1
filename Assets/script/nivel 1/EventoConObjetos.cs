using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoConObjetos : MonoBehaviour
{
    public float Vida;
    public int monedas;
    public int puntosComida;
    public GameObject explosion1;
    public GameObject explosion2;
    public GameObject explosion3;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "moneda")
        {
            monedas = monedas + 1;
           Destroy(collision.transform.gameObject, 0.1f);
        }
          if (collision.transform.tag == "corazon")
        {
                 Vida = Vida + 10;
            Destroy(collision.transform.gameObject, 0.1f);
        }
        if (collision.transform.tag == "comida")
        {
            puntosComida = puntosComida + 1;
            Destroy(collision.transform.gameObject, 0.1f);
        }
        if(collision.transform.tag == "Trampa")
        {
            Vida = Vida - 20;
            Destroy(collision.transform.gameObject, 0.1f);
        }
        if (collision.transform.name == "bomba")
        {
            Vida = Vida - 30;
            explosion1.SetActive(true);

            Destroy(collision.transform.gameObject, 0.1f);
        }
        if (collision.transform.name == "bomba1")
        {
            Vida = Vida - 30;
            explosion2.SetActive(true);

            Destroy(collision.transform.gameObject, 0.1f);
        }
        if (collision.transform.name == "bomba2")
        {
            Vida = Vida - 30;
            explosion3.SetActive(true);

            Destroy(collision.transform.gameObject, 0.1f);
        }
        if (puntosComida >= 10)
        {
            Debug.Log("Felicidades, ganaste la partida");
            Time.timeScale = 0f;
        }
        if(Vida <= 0)
        {
            Debug.Log("Has perdido, tu vida llego a 0");
            Time.timeScale = 0f;
        }
    }
   
}
