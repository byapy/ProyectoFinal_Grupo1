using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverBala : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(90,0,0);
        Destroy(gameObject, 2f);  
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }
    public void Movimiento()
    {
        
        Vector3 movimiento = new Vector3(0, 0.9f, 0);
        transform.Translate(movimiento);
    }
}
