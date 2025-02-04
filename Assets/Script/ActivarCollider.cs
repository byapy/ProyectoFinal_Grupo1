using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarCollider : MonoBehaviour
{
    public int monedas;
    public int vida;
    public GameObject cubo;
    public GameObject particula;
    public Vector3 escala;

    void Start()
    {

    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Coin")
        {
            monedas = monedas + 1;
            Destroy(collision.transform.gameObject);
            Debug.Log(monedas);
        }

        if (collision.transform.tag == "Trampa")
            vida = vida - 10;
        Debug.Log("Has caido en la trampa, te queda " + vida + "de vida");
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Has salido del área de veneno");
        particula.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Estas adentro del área de veneno");
        vida = vida - 1;
        cubo.transform.Rotate(10, 0, 0);
        particula.SetActive(true);
    }

    public void Vida()
    {
        vida = vida - 10;
        Debug.Log("La vida es" + vida);
    }
}
