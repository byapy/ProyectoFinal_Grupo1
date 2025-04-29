using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    public int velocidad;
    public bool activar;
    void Start()
    {
        
    }

    void Update()
    {
        
        if (Input.GetButton("Jump"))
        {
            Movimiento();
        }                        
    }
   
    
    public void Movimiento()
    {
        transform.Rotate(0, velocidad, 0);
    }
  
}
