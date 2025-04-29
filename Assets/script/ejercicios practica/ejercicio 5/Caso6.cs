using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caso6 : MonoBehaviour
{
    public GameObject cubo;
    public GameObject esfera;
    public GameObject cilindro;
    public bool girarCubo;
    public bool girarCilindro;
    public float velocidadCilindro;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (girarCubo == true)
        {
            cubo.transform.Rotate(1, 0, 0);
        }
        if (Input.GetButtonDown("Jump"))
        {
        esfera.transform.Translate(5, 0, 0);
        }
       
        if ( girarCilindro == true)
        {
            cilindro.transform.Rotate(velocidadCilindro, 0, 0);
        }
        
    }
}
