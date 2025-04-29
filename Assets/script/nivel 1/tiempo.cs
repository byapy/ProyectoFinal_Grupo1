using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiempo : MonoBehaviour
{
    public float tiempoLimite;
    
    // Start is called before the first frame update
    void Start()
    {
       Debug.Log("Has activado el tiempo limite, recolecta toda la comida que puedas para pasar al siguiente nivel, cuidado con las bombas");
    }

    // Update is called once per frame
    void Update()
    {
        Temporizador();
    }
    void Temporizador()
    {
       tiempoLimite = tiempoLimite - Time.deltaTime;
        if (tiempoLimite <= 0)
        {
           Time.timeScale = 0f;
           Debug.Log("Se acabo el tiempo, perdiste");
        }
    }
}
