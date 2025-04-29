using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estadisticasEnemigo : MonoBehaviour
{
    public int saludEnemigo;
    public Animator animacionEnemigo;
    // Start is called before the first frame update
    void Start()
    {
        animacionEnemigo = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "espada")
        {
            saludEnemigo = saludEnemigo - 10;
            animacionEnemigo.SetBool("golpe", true);
            //if (saludEnemigo <= 0 )
           // {
             //   animacionEnemigo.SetBool("derrota", true);
             //   Destroy(gameObject, 5f);
                
        }
      //  }
      //  else
       // {
      //      animacionEnemigo.SetBool("golpe", false);
       // }
    }
}
