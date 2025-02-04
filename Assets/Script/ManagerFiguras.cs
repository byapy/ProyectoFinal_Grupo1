using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerFiguras : MonoBehaviour
{
    public GameObject cubito;
    public GameObject esfera;
    public GameObject cilindro;
    public bool activarCubo;
    public bool activarCilindro;
    public float velocidad;

    /*public GameObject Objeto;
    public GameObject nido;*/

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(activarCubo == true)
        {
            cubito.transform.Rotate(0.1f, 0, 0);
        }

        if (Input.GetButtonDown("Jump"))
        {
            esfera.transform.Translate(5, 0, 0);
        }
        if (activarCubo == true)
        {
            cilindro.transform.Rotate(velocidad, 0, 0);
        }

       
        /*if(Input.GetButtonDown("Jump"))
        {
            Instantiate(Objeto, nido.transform.position, nido.transform.rotation);
        }*/

    }
       
}
