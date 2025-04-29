using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caso5 : MonoBehaviour
{
    public float velocidad1;
    public float velocidad2;
    public bool velocidadAlta;

    // Start is called before the first frame update
    void Start()
    {
        Saludo();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(velocidad1, 0, 0);

        if (velocidadAlta == true)
        {
            transform.Rotate(velocidad2, 0, 0);
            Despedida();
        }
    }
    public void Saludo()
    {
        Debug.Log("Bienvenidos a todos");
    }
    public void Despedida()
    {
        Debug.Log("Hasta luego");
    }
}
