using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCharacterController : MonoBehaviour
{
    public CharacterController Controller;
    public float velocidad;
    public Vector3 caida;
    public float gravedad = -9.81f;
    public Transform detectar;
    public float Distancia = 0.4f;
    public LayerMask Terreno;
    public bool suelo;
    public float salto;

    public Camera fpscamara;
    public float rango;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        suelo = Physics.CheckSphere(detectar.position, Distancia, Terreno);
        if(suelo && caida.y < 0)
        {
            caida.y = -2f;
        }
        float movx = Input.GetAxis("Horizontal");
        float movz = Input.GetAxis("Vertical");

        Vector3 mover = transform.right * movx + transform.forward * movz;
        Controller.Move(mover * velocidad * Time.deltaTime);
       
        if(Input.GetButtonDown("Jump") && suelo)
        {
            caida.y = Mathf.Sqrt(salto * -2f * gravedad);
        }

        caida.y += gravedad * Time.deltaTime;
        Controller.Move(caida * Time.deltaTime);
    }
    
}
