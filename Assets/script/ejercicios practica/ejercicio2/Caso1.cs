using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caso1 : MonoBehaviour
{
    public int valor1;
    public int valor2;
    public int resultado;
    public string nombre;

    void Start()
    {
    resultado = valor1 - valor2;
    Debug.Log(nombre + resultado);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
