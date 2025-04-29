using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recolectarJugador2D : MonoBehaviour
{
    public int bolsaDeMonedas;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Debes llegar a la meta para completar el nivel, hay muchas monedas que puedes agarrar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag == "moneda")
        {
            bolsaDeMonedas = bolsaDeMonedas + 1;
            Debug.Log("Conseguinste 1 moneda y llevas " + bolsaDeMonedas);
            Destroy(collision.transform.gameObject);
            if (bolsaDeMonedas >= 15)
            {
                Debug.Log("Felicidades conseguistes todas las monedas");
            }
        }
        
            
    }
    private void OnTriggerStay(Collider derrota)
    {
        if (derrota.transform.tag == "muerte")
        {
        Debug.Log("Te has caido de las plataformas y pierdes la partida");
        Time.timeScale = 0f;
        }
    }
}
