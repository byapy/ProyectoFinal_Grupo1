using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caso7 : MonoBehaviour
{
    public GameObject objeto;
    public GameObject jugador;
   // public GameObject destello;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetButtonDown("Fire1"))
        if (Input.GetMouseButtonDown(2))
        {
            Instantiate(objeto, jugador.transform.position, jugador.transform.rotation);
        
        
        }
   
    }
}

