using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caso8 : MonoBehaviour
{
    public int poder;
    public int puntosSalud;
    public GameObject objeto;
    public GameObject caja;
    public GameObject destello;
    public GameObject luz1;
    public GameObject luz2;
    public Vector3 pequeno;
    public Vector3 grande;

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
        if (collision.transform.tag == "energia")
        {
            poder = poder + 1;
            Debug.Log("obtienes " + poder + " de energia");
            Destroy(collision.transform.gameObject, 0.1f);
        }
        if (collision.transform.tag == "puas")
        {
            puntosSalud = puntosSalud - 10;
            Debug.Log("Vida " + puntosSalud);
        }
    }
        private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "evento")
        {
            transform.localScale = pequeno;
            puntosSalud = puntosSalud - 20; 
        }
     }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.name == "evento")
        {
            objeto.transform.Rotate(1, 0, 0);
            caja.transform.Rotate(0, 1, 0);
            destello.SetActive(true);
            luz1.SetActive(true);
            luz2.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.name == "evento")
        {
            transform.localScale = grande;
            Debug.Log("Has salido del area");
            destello.SetActive(false);
            luz1.SetActive(false);
            luz2.SetActive(false);
            puntosSalud = puntosSalud + 20;
        }
    }
    
}
