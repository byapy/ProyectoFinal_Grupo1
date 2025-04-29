using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambioDeCamaras : MonoBehaviour
{
    public GameObject camaraTerPersona;
    public GameObject camaraPriPersona;
    public GameObject espada;
    public GameObject espada2;
    public GameObject pistola;
    public int salud;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IntecambioDeCamaras();
    }
    public void IntecambioDeCamaras()
    {
        if (Input.GetKey(KeyCode.J)) 
        {
            camaraTerPersona.SetActive(false);
            camaraPriPersona.SetActive(true);
            GetComponent<ThirdPersonMover>().enabled = false;
            GetComponent<FPSCharacterController>().enabled = true;
            GetComponent<Caso7>().enabled = true;
            espada.SetActive(false);
            espada2.SetActive(false);
            pistola.SetActive(true);
        }
        if (Input.GetKey(KeyCode.F))
        {
            camaraTerPersona.SetActive(true);
            camaraPriPersona.SetActive(false);
            GetComponent<ThirdPersonMover>().enabled = true;
            GetComponent<FPSCharacterController>().enabled = false;
            GetComponent<Caso7>().enabled = false;
            espada.SetActive(true);
            pistola.SetActive(false);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "espada")
        {
            salud = salud - 25;
        }
    }
}
