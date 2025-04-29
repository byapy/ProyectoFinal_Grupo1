using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caso3 : MonoBehaviour
{
    public float numero1;
    public float numero2;
    public float resultado;
    public string nombre;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        resultado = numero1 + numero2;
        Debug.Log(nombre + resultado);
    }
}
