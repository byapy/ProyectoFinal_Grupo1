using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class estadisticasJugador : MonoBehaviour
{
    public static estadisticasJugador Instance;

    public static float salud = 100f;
    public static float gemas = 0f;

    public GameObject espada1;
    public GameObject espada2;
    public GameObject particula;

    public GameObject derrota;
    public GameObject esfera;

    public GameObject mandobleElec;
    public GameObject espadaHie;

    public Animator animacion1;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ataque();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "moneda")
        {
            gemas = gemas + 1f;
            Destroy(collision.transform.gameObject);
        }
        if (collision.transform.tag == "bala")
        {
            salud = salud - 10f;
            Destroy(collision.transform.gameObject);
        }
        if (collision.transform.tag == "Trampa")
        {
            salud = salud - 5f;
            
        }
        if (salud <= 0)
        {
            derrota.SetActive(true);
            Time.timeScale = 0f;

        }

    }

    public void OnTriggerEnter(Collider dano)
    {
        if (dano.transform.tag == "puas")
        {
            salud = salud - 5f;
            if (salud <= 0)
            {
                derrota.SetActive(true);
                Time.timeScale = 0f;

            }
            
        }

    }
    public void Ataque()
    {
        if (Input.GetMouseButtonDown(1))
        {
         
           
                animacion1.SetBool("Ataque", true);
                esfera.SetActive(true);
           
            
        }
        else
        {
            animacion1.SetBool("Ataque", false);
            esfera.SetActive(false);
        }
    }

    public void cambioDeEspada1()
    {
        espada1.SetActive(true);
        espada2.SetActive(false);
        espadaHie.SetActive(false);
        mandobleElec.SetActive(false);

    }
    public void cambioDeEspada2()
    {
        espada2.SetActive(true);
        espada1.SetActive(false);
        espadaHie.SetActive(false);
        mandobleElec.SetActive(false);
    }
    public void masSalud()
    {
        salud = salud + 5;
        particula.SetActive(true);
    }

    public void reiniciar()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        salud = 100f;
        gemas = 0f;
        derrota.SetActive(false);
    }

    public void agregarSalud(int valor)
    {
        salud += valor;
    }

    public void activarEspadaHielo()
    {
        espadaHie.SetActive(true);
        mandobleElec.SetActive(false);
        espada1.SetActive(false);
        espada2.SetActive(false);
    }

    public void activarMandobleElectrico()
    {
        espadaHie.SetActive(false);
        mandobleElec.SetActive(true);
        espada1.SetActive(false);
        espada2.SetActive(false);
    }
}
