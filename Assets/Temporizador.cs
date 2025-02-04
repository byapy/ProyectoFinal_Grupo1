using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporizador : MonoBehaviour
{
    public float tiempo;
    public float tiempoRestante;
    public GameObject particulaExplosion;
        
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempoRestante = tiempoRestante - Time.deltaTime;
        if(tiempoRestante <= 0)
        {
            particulaExplosion.SetActive(true);
            Resetear();
            Time.timeScale = 0f;
        }
    }
    public void Resetear()
    {
        tiempoRestante = tiempo;
    }
}
