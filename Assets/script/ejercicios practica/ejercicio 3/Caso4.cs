using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caso4 : MonoBehaviour
{
    public float velocidad;
    public float giro;
    public bool activarRotacion;
    public bool activarMovimiento;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Bienvenidos");
    }

    void Update()
    {
        if (activarRotacion == true)
        {
            Rotar();
        }
        if (activarMovimiento == true)
        {
            Mover();
        }
    }
    public void Mover()
    {
        transform.Translate(0, velocidad, 0);
    }
    public void Rotar()
    {
        transform.Rotate(0, giro, 0);
    }

}
