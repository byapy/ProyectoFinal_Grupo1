using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectarColision : MonoBehaviour
{
    public float puntosVida;
    public GameObject bomba1;
    public GameObject bomba2;
    public GameObject bomba3;
    public GameObject bomba4;
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
        if (collision.transform.tag == "Trampa")
        {
            puntosVida = puntosVida - 5;
        }
        if(collision.transform.tag == "comida")
        {
            puntosVida = puntosVida + 15;
            Destroy(collision.transform.gameObject);
            Debug.Log("Consegiste comida tu salud aumenta puntos");
        }
        if (collision.transform.name == "bomba1")
        {
            puntosVida = puntosVida - 10;
            Destroy(collision.transform.gameObject);
            bomba1.SetActive(true);
            Debug.Log("Chocaste con una bomba");
        }
        if (collision.transform.name == "bomba2")
        {
            puntosVida = puntosVida - 10;
            Destroy(collision.transform.gameObject);
            bomba2.SetActive(true);
            Debug.Log("Chocaste con una bomba");
        }
        if (collision.transform.name == "bomba3")
        {
            puntosVida = puntosVida - 10;
            Destroy(collision.transform.gameObject);
            bomba3.SetActive(true);
            Debug.Log("Chocaste con una bomba");
        }
        if (collision.transform.name == "bomba4")
        {
            puntosVida = puntosVida - 10;
            Destroy(collision.transform.gameObject);
            bomba4.SetActive(true);
            Debug.Log("Chocaste con una bomba");
        }
        
        if(puntosVida <= 0)
        {
            Time.timeScale = 0f;
            Debug.Log("Perdiste tu vida llego a 0");
        }
    }
    private void OnTriggerStay(Collider peligro)
    {
        if(peligro.transform.tag == "Constante")
        {
            puntosVida = puntosVida - 0.1f;
        }
        if (peligro.transform.tag == "muerte")
        {
            Debug.Log("Has caido en la zona verde y pierdes toda la vida");
            Time.timeScale = 0f;
        }
    }

}
