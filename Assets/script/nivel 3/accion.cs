using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accion : MonoBehaviour
{
    public float vida;
    public int esferas;
    public int totalEsferas;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Destruye todas la esfera para ganar"); 
    }

    // Update is called once per frame
    void Update()
    {
        victoria();
        
    }
    public void OnCollisionEnter(Collision collision)
    {
       if (collision.transform.tag == "Trampa")
        {
          esferas = esferas + 1;
          Destroy(collision.transform.gameObject);
          Debug.Log("Destruiste una esfera");
        }
        if (collision.transform.tag == "comida")
        {
            vida = vida + 5;
            Debug.Log("Conseguiste coimda");
            Destroy(collision.transform.gameObject);

        }
              
    }
    public void victoria()
    {
        if (esferas >= 15)
        {
            Debug.Log("Felicidades, superaste este nivel");
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Constante")
        {
            vida = vida - 0.1f;
        }
           
        if (vida <= 0f)
        {
            Time.timeScale = 0f;
            Debug.Log("Perdiste tu vida llego a 0");
        }
    }

}
