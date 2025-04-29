using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caso2 : MonoBehaviour
{
    public int valor1;
    public int resultado;
    public string mensaje;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        resultado = resultado + valor1;
        Debug.Log("El resultado es en " + mensaje + resultado);
            }
}
