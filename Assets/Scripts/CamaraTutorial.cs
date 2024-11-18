using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraTutorial : MonoBehaviour
{
    float Temporizador = 8f;
    bool EntroJugador, Exploto;
    public GameObject CamaraNormal, CamaraCinematica, Gargola, ParticulaGargola;
    public Transform PosicionGargola;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            TiempoCamara();
    }

    void TiempoCamara()
    {
        Temporizador -= 1 * Time.deltaTime;
        
        if(Temporizador <= 6f && !Exploto)
        {
            Instantiate(ParticulaGargola, PosicionGargola);
            Instantiate(Gargola, PosicionGargola);
            Debug.Log("Al fin has llegado. Acercate, debo hablar contigo.");
            Exploto = true;
        }

        if(Temporizador <= 0)
        {
            Destroy(gameObject);
            CamaraNormal.SetActive(true);
            Destroy(CamaraCinematica);
        }
    }
}
