using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float movX;
    public float movZ;
    public float velocidad;
    public float rotY;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movimientos();
    }
    public void Movimientos()
    {
      movX = Input.GetAxis("Horizontal");
      movZ = Input.GetAxis("Vertical");
      rotY = Input.GetAxis("Mouse X");
        Vector3 movimiento = new Vector3(movX, 0, movZ);

        transform.Translate(movimiento * velocidad * Time.deltaTime);
        transform.Rotate(0, rotY, 0);
    } 
    
}
