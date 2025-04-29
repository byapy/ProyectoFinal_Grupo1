using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danarEnemigos : MonoBehaviour
{
    public int saludEnemigo;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "simitarra")
        {
            saludEnemigo = saludEnemigo - 10;
        }
    }
}
