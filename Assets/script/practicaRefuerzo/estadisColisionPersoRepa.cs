using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estadisColisionPersoRepa : MonoBehaviour
{
    public int salud;
    public int monedas;
    public GameObject meta;
    public GameObject particula;
    public GameObject luz1;
    public GameObject luz2;
    public GameObject luz3;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Debes encontrar la llave con forma de Estrella para que aparezca el camino oculto que te llevara a la meta"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision objeto)
    {
        if(objeto.transform.tag == "moneda")
        {
            monedas = monedas + 1;
            Debug.Log("Consiges 1 moneda y tienes " + monedas);
            Destroy(objeto.transform.gameObject);
        }
        if (objeto.transform.tag == "monedas")
        {
            monedas = monedas + 10;
            Debug.Log("Consiges 10 monedas y tienes " + monedas);
            Destroy(objeto.transform.gameObject);
        }
        if (objeto.transform.tag == "corazon")
        {
            salud = salud + 1;
            Debug.Log("Consiges 1 punto de salud y tienes " + salud);
            Destroy(objeto.transform.gameObject);
        }
        
        if (objeto.transform.tag == "puas")
        {
            salud = 0;
            Debug.Log("Has perdido la partida");
            Time.timeScale = 0f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {       
       if (other.transform.tag == "Finish")
        {
         meta.SetActive(true);
         luz1.SetActive(true);
         luz2.SetActive(true);
         luz3.SetActive(true);
         particula.SetActive(true);
         Debug.Log("Ganaste el Nivel 1");
        }    
        
    }
    private void OnTriggerStay(Collider derrota)
    {
    if (derrota.transform.tag == "muerte")
      {
        salud = 0;
        Debug.Log("Has perdido");
        Time.timeScale = 0f;
      }
    }
}
