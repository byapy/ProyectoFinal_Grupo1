using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danoDeEnemigos : MonoBehaviour
{
    public int salud;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "espada")
        {
            salud = salud - 25;
        }
        if (collision.transform.tag == "mandoble")
        {
            salud = salud - 50;
        }
        if (collision.transform.tag == "moneda")
        {
            Destroy(collision.transform.gameObject);
        }
    }
}
