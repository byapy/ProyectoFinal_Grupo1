using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsEnemigo : MonoBehaviour
{


    public float VidaEnemigo, Damage;

    private enum DamageType
    {
        Espada,
        Patada,
    }

    // Start is called before the first frame 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Player"))
         UIController.Instance.MensajeAConsola(collision.GetContact(0).ToString());
    }


}
