using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminar_Juego : MonoBehaviour
{
   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (JefaLilith.Instance.VidaLilith == 0)
            {
                Debug.Log("Trono disponible");
            }
        }
            
    }
}
