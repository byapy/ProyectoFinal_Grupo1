using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoFPS : MonoBehaviour
{
    public float movX;
    public float movZ;

    public float RotY;
    public float velocidad;   

   
     void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoCamara();        
    }
    public void MovimientoCamara()
    {        

        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");

        RotY = Input.GetAxis("Mouse X");

        Vector3 movimiento = new Vector3(movX,0,movZ);

        transform.Translate(movimiento * velocidad * Time.deltaTime);
        transform.Rotate(0, RotY, 0);
    }
}
