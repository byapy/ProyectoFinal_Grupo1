using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esqueletosAtaque : MonoBehaviour
{
    public CharacterController Controlar;
    public float velocidad;
    public float rapidoSmooth = 0.1f;
    public float sensibleSmooth;
    public Transform camara;

    public Animator animacion;
    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void combate()
    {
        if (Input.GetKey(KeyCode.K))
        {
            animacion.SetBool("Ataque 1", true);
        }
        else
        {
            animacion.SetBool("Ataque 1", false);
        }
    }
}
