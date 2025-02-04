using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int vidaEnemigo = 100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Hacha")
        {
            Debug.Log("Atacando");
            vidaEnemigo = vidaEnemigo - 1;
            if(vidaEnemigo == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
