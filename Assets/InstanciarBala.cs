using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarBala : MonoBehaviour
{
    public GameObject Bala;
    public GameObject Pointer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {            
            Disparo();
        }
    }
    void Disparo()
    {
        Instantiate(Bala, Pointer.transform.position, Pointer.transform.rotation);
    }
}
