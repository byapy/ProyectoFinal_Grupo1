using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class espada : MonoBehaviour
{
    public Animator espadas;
   
    // Start is called before the first frame update
    void Start()
    {
        espadas = GetComponentInChildren<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        golpe();
        
    }
    public void golpe()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            espadas.SetBool("Espada", true);
        }
        else
        {
            espadas.SetBool("Espada", false);
        }
    }
}
